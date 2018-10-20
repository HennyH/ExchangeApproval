import m from 'mithril'

import StaffDecisionSearchSettingsPanel from './StaffDecisionSearchSettingsPanel.js'

const Data = {
    filters: {
        options: null,
        fetch: () => {
			//This all needs to be replaced with requested data
            Data.filters.options = {
                studentOptions: ['Henry Hollingworth (21471423)', 'Augustin Gan (21487462)'],
                studentOfficeOptions: ['Business School', 'Law School'],
                applicationStateOptions: [
                    'New',
                    'Incomplete',
                    'Complete'
                ],
                dateOptions: [
                ]
            };
            // m.request({
            //     method: "GET",
            //     url: "/api/requests/filters"
            // }).then(options => {
            //     Data.filters.options = options;
            // });
        }
    }
}

export default function StaffDecisionSearchSettingsPanelContainer() {
    function oninit() {
        Data.filters.fetch();
    }

    function view({ attrs }) {
        if (!Data.filters.options) {
            return <div />;
        }

        return (
            <StaffDecisionSearchSettingsPanel {...attrs} {...Data.filters.options} />
        );
    }

    return { oninit, view };
}