import m from 'mithril'

import SearchSettingsPanelContainer from './SearchSettingsPanelContainer'
import DecisionsTable from './DecisionsTable'

const Data = {
    decisions: {
        list: [],
        fetch: ({ approvalTypes: contextId = [], unitLevels: levelId = [], exchangeUniversities: universityId = [] } = {}) => {
            const qs = m.buildQueryString({ contextId, levelId, universityId });
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

    let state = {}

    function oninit() {
        Data.decisions.fetch();
    }

    function handleSearchPanelSubmit(settings) {
        Data.decisions.fetch(settings);
    }

    function view() {
        return (
            <div class="container">
                <div class="row">
                    <div class="col-12">
                        <SearchSettingsPanelContainer handleSubmit={handleSearchPanelSubmit} />
                    </div>
                </div>
                <hr />
                <div class="row">
                    <div class="col-12">
                        <h5>Search Results</h5>
                        <DecisionsTable id="search-decisions" decisions={Data.decisions.list} />
                    </div>
                </div>
            </div>
        );
    }

    return { view, oninit };
}