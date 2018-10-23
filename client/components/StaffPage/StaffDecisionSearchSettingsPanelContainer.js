import m from 'mithril'
import {ApplicationSearchData as Data} from '../ViewData'
import StaffDecisionSearchSettingsPanel from './StaffDecisionSearchSettingsPanel.js'

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