import m from 'mithril'

import Layout from 'Components/Layout'
import SearchSettingsPanelContainer from './SearchSettingsPanelContainer.js'
import DecisionsTable from './DecisionsTable.js'
import { addItemToCart, default as Cart } from 'Components/Cart';

const Data = {
    decisions: {
        list: [],
        fetch: ({ contextIds = [], levelIds = [], universityIds = [] } = {}) => {
            const qs = m.buildQueryString({
                contextId: contextIds,
                levelId: levelIds,
                universityId: universityIds
            });
            m.request({
                method: "GET",
                url: "https://localhost:5001/api/values/decisions?" + qs
            }).then(items => {
                Data.decisions.list = items;
            });
        }
    }
}

export default function SearchPage() {

    function oninit() {
        if (Data.decisions.list.length === 0) {
            Data.decisions.fetch();
        }
    }

    function handleSearchPanelSubmit(settings) {
        const universityIds = settings.exchangeUniversities.map(({ value: id }) => id);
        const contextIds = settings.approvalTypes.map(({ value: id }) => id);
        const levelIds = settings.unitLevels.map(({ value: id }) => id);
        Data.decisions.fetch({ universityIds, contextIds, levelIds });
    }

    function view() {
        return (
            <Layout>
                <div class="container">
                    <div class="card bg-light mt-3 mb-3">
                        <div class="card-header">Search Settings</div>
                        <div class="card-body">
                            <SearchSettingsPanelContainer onsubmit={handleSearchPanelSubmit} />
                        </div>
                    </div>
                    <div class="card bg-light mb-3">
                        <div class="card-header">Unit Cart</div>
                        <div class="card-body">
                            <Cart />
                        </div>
                    </div>
                    <div class="card bg-light mb-3">
                        <div class="card-header">Search Results</div>
                        <div class="card-body">
                            <DecisionsTable
                                decisions={Data.decisions.list}
                                onAddToCart={addItemToCart}
                            />
                        </div>
                    </div>
                </div>
            </Layout>
        );
    }

    return { view, oninit };
}