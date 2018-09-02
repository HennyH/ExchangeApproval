import m from 'mithril'

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
        Data.decisions.fetch();
    }

    function handleSearchPanelSubmit(settings) {
        const universityIds = settings.exchangeUniversities.map(({ value: id }) => id);
        const contextIds = settings.approvalTypes.map(({ value: id }) => id);
        const levelIds = settings.unitLevels.map(({ value: id }) => id);
        Data.decisions.fetch({ universityIds, contextIds, levelIds });
    }

    function view() {
        return (
            <div class="container">
                <div class="row">
                    <div class="col-12">
                        <SearchSettingsPanelContainer onsubmit={handleSearchPanelSubmit} />
                    </div>
                </div>
                <hr />
                <div class="row">
                    <div class="col-12" style="border: 1px solid black;">
                        <h5>Cart</h5>
                        <Cart />
                    </div>
                </div>
                <hr />
                <div class="row">
                    <div class="col-12">
                        <h5>Search Results</h5>
                        <DecisionsTable
                            decisions={Data.decisions.list}
                            onAddToCart={addItemToCart}
                        />
                    </div>
                </div>
            </div>
        );
    }

    return { view, oninit };
}