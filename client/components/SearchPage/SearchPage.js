import m from 'mithril';
import classNames from 'classnames';

import Layout from 'Components/Layout';
import { addItemToCart, default as Cart } from 'Components/Cart';
import DecisionSearchSettingsPanel from './DecisionSearchSettingsPanel.js';
import DecisionsTable from './DecisionsTable.js';
import DataLoader from 'Components/DataLoader.js'
import Spinner from 'Components/Spinners/RectangularSpinner.js';

function UnitSearch() {

    const state = {
        hasClickedSearch: false,
        searchSettings: { universityNames: [], uwaContextTypes: [], uwaUnitLevels: [] }
    }

    function handleSearchSettingsChanged(settings) {
        const universityNames = settings.exchangeUniversities.map(({ value }) => value);
        const uwaContextTypes = settings.approvalTypes.map(({ value }) => value);
        const uwaUnitLevels = settings.unitLevels.map(({ value }) => value);
        state.hasClickedSearch = true;
        state.searchSettings = { universityNames, uwaContextTypes, uwaUnitLevels };
        m.redraw();
    }

    function fetchEquivalencies() {
        const qs = m.buildQueryString(state.searchSettings);
        return m.request({ method: "GET", url: `/api/equivalencies?${qs}` });
    }

    function view() {
        return(
            <div class="card mt-3">
                <div class="card-header">
                    Unit Search
                </div>
                <div class="card bg-light m-3">
                <div class="card-header">Search Settings</div>
                <DataLoader
                    requests={{filters: () => m.request("/api/filters/student")}}
                    render={({loading, errored, data: { filters: { exchangeUniversityNameOptions, uwaUnitLevelOptions, uwaUnitContextOptions } = {} }}) => (
                        <div class={classNames("card-body", loading ? "text-center" : "")}>
                                {loading
                                    ? <Spinner />
                                    : <DecisionSearchSettingsPanel
                                            onSearchSettingsChanged={handleSearchSettingsChanged}
                                            exchangeUniversityOptions={exchangeUniversityNameOptions}
                                            levelOptions={uwaUnitLevelOptions}
                                            contextOptions={uwaUnitContextOptions}
                                    />
                                }
                        </div>
                    )}
                />
                </div>
                <div class="card bg-light m-3">
                    <div class="card-header">Search Results</div>
                        <DataLoader
                            requests={{equivalencies: fetchEquivalencies}}
                            render={({ loading, errored, data: { equivalencies } = {}}) => (
                                <div class={classNames("card-body", loading ? "text-center" : "")}>
                                    {state.hasClickedSearch ?
                                        (loading
                                            ? <Spinner />
                                            : <DecisionsTable
                                                decisions={equivalencies}
                                                onAddToCart={addItemToCart}
                                            />
                                        )
                                    : <p class="my-0"><em>Search to see previously approved exchange units</em></p>}
                                </div>
                            )}
                        />
                </div>
            </div>
        )
    }

    return { view };
}

export default function SearchPage() {

    function view() {

        return (
            <Layout>
                <div class="container-fluid">
                    <UnitSearch/>
                </div>
                <div class="container-fluid">
                    <Cart/>
                </div>
            </Layout>
        );
    }

    return { view };
}
