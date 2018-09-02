import m from 'mithril'

import SearchSettingsPanelContainer from './SearchSettingsPanelContainer'
import DecisionsTable from './DecisionsTable'

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