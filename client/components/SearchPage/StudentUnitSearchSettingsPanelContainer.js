import m from 'mithril'

import StudentUnitSearchSettingsPanel from './StudentUnitSearchSettingsPanel'

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
    }
}

export default function StudentUnitSearchSettingsPanelContainer() {
    function oninit() {
        Data.filters.fetch();
    }

    function view({ attrs }) {
        if (!Data.filters.options) {
            return <div />;
        }

        return (
            <StudentUnitSearchSettingsPanel
                {...attrs}
                exchangeUniversities={Data.filters.options.exchangeUniversityNames}
                levelOptions={Data.filters.options.uwaUnitLevelOptions}
                contextOptions={Data.filters.options.uwaUnitContextOptions}
            />
        );
    }

    return { oninit, view };
}