import m from 'mithril';
import classNames from 'classnames';

import Layout from 'Components/Layout';

import { addItemToCart, default as Cart } from 'Components/Cart';
import DecisionSearchSettingsPanel from './DecisionSearchSettingsPanel.js';
import Spinner from 'Components/Spinners/RectangularSpinner.js';
import DecisionsTable from './DecisionsTable.js';

const Data = {
    filters: {
        options: null,
        fetch: () => {
            m.request({
                method: "GET",
                url: "/api/requests/filters"
            }).then(options => {
                Data.filters.options = options;
            });
        }
    },
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
                url: `/api/requests/decisions?${qs}`
            }).then(items => {
                Data.decisions.list = items;
                Data.decisions.loading = false;
            });
        }
    }
}


export default function SearchPage() {

    function oninit() {
        Data.filters.fetch();
        Data.decisions.fetch();
    }

    function view() {

        return (
            <Layout>
                <div class="container">
                    <div class="card bg-light mb-3">
                        <div class="card-header">Search Settings</div>
                        <div class="card-body">
                            <DecisionSearchSettingsPanel
                                onSearchSettingsChanged={handleSearchSettingsChanged}
                                exchangeUniversityOptions={Data.filters.options.exchangeUniversityNames}
                                levelOptions={Data.filters.options.uwaUnitLevelOptions}
                                contextOptions={Data.filters.options.uwaUnitContextOptions}
                            />
                        </div>
                    </div>
                    <div class="card bg-light mb-3">
                        <div class="card-header">Cart</div>
                        <div class="card-body">
                            <Cart />
                        </div>
                    </div>
                    <div class="card bg-light mb-3">
                        <div class="card-header">Search Results</div>
                        <div class={classNames("card-body", Data.decisions.loading ? "text-center" : "")}>
                            {(Data.decisions.loading
                                ? <Spinner />
                                : <DecisionsTable
                                    decisions={Data.decisions}
                                    onAddToCart={addItemToCart}
                                />
                            )}
                        </div>
                    </div>
                </div>
                <div />
            </Layout>
        );
    }

    function handleSearchSettingsChanged(settings) {
        const universityNames = settings.exchangeUniversities.map(({ value }) => value);
        const uwaContextTypes = settings.approvalTypes.map(({ value }) => value);
        const uwaUnitLevels = settings.unitLevels.map(({ value }) => value);
        Data.decisions.fetch({ universityNames, uwaContextTypes, uwaUnitLevels });
        m.redraw();
    }

    return { oninit, view };
}
