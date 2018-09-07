import m from 'mithril'
import classNames from 'classnames';

import Layout from 'Components/Layout'
import StudentUnitSearchSettingsPanelContainer from './StudentUnitSearchSettingsPanelContainer.js'
import Spinner from 'Components/Spinners/RectangularSpinner';
import DecisionsTable from './DecisionsTable.js'
import { addItemToCart, default as Cart } from 'Components/Cart';

const Data = {
    decisions: {
        loading: false,
        list: [],
        fetch: ({ universityNames = [], uwaContextTypes = [], uwaUnitLevels = [] } = {}) => {
            Data.decisions.loading = true;
            const qs = m.buildQueryString({
                universityNames,
                uwaContextTypes,
                uwaUnitLevels
            });
            m.request({
                method: "GET",
                url: `/api/requests/decisions?${qs}"`
            }).then(items => {
                Data.decisions.list = items;
                Data.decisions.loading = false;
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
        console.log(settings);
        const universityNames = settings.exchangeUniversities.map(({ value }) => value);
        const uwaContextTypes = settings.approvalTypes.map(({ value }) => value);
        const uwaUnitLevels = settings.unitLevels.map(({ value }) => value);
        Data.decisions.fetch({ universityNames, uwaContextTypes, uwaUnitLevels });
        m.redraw();
    }

    function view() {
        return (
            <Layout>
                <div class="container-fluid">
                    <div class="card bg-light mt-3 mb-3">
                        <div class="card-header">Search Settings</div>
                        <div class="card-body">
                            <StudentUnitSearchSettingsPanelContainer onsubmit={handleSearchPanelSubmit} />
                        </div>
                    </div>
                    <div class="card bg-light mb-3">
                        <div class="card-header">Unit Cart</div>
                        <div class="card-body">
                            <Cart />
                        </div>
                    </div>
                    <div class={classNames("card bg-light mb-3", Data.decisions.loading ? "text-center": "")}>
                        <div class="card-header">Search Results</div>
                        <div class="card-body">
                            {(Data.decisions.loading
                                ? (<Spinner />)
                                : (
                                    <DecisionsTable
                                        decisions={Data.decisions.list}
                                        onAddToCart={addItemToCart}
                                    />
                                )
                            )}
                        </div>
                    </div>
                </div>
            </Layout>
        );
    }

    return { view, oninit };
}