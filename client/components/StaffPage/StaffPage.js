import m from 'mithril'
import classNames from 'classnames';

import Layout from 'Components/Layout'
import StaffDecisionSearchSettingsPanel, { StaffUnitSearchSettingsPowerForm } from './StaffDecisionSearchSettingsPanel.js'
import InboxTable from './InboxTable.js';
import Spinner from 'Components/Spinners/RectangularSpinner.js';
import PersistentDataLoader from 'Components/PersistentDataLoader.js'

export default function StaffPage() {

    const state = {
        inboxSearchSettings: { applicationStatuses: [], studentNumbers: [], studentOffices: [] },
        inboxSearchSettingsForm: null
    };

    function handleSearchSettingsChanged(settings) {
        const applicationStatuses = settings.applicationStatuses.map(({ value }) => value);
        const studentNumbers = settings.studentNumbers.map(({ value }) => value);
        const studentOffices = settings.studentOffices.map(({ value }) => value);
        state.inboxSearchSettings = { applicationStatuses, studentNumbers, studentOffices };
        m.redraw();
    }

    function fetchInbox(settings) {
        const qs = m.buildQueryString(settings);
        return m.request({ method: "GET", url: `/api/inbox?${qs}` });
    }

    function view() {
        return (
            <Layout staff = {true} >
                <div class="container-fluid">
                    <div class="row">
                        <div class="col">
                            <div class="card bg-light mt-3 mb-3">
                                <div class="card-header">Inbox Search Settings</div>
                                <PersistentDataLoader
                                    id="staff-page-filters"
                                    requests={{filters: () => m.request("/api/filters/staff")}}
                                    render={({ loading, error, data: { filters } = {}}) => {
                                        const hidePanel = !!(loading || error);
                                        if (state.inboxSearchSettingsForm == null && !hidePanel) {
                                            state.inboxSearchSettingsForm = new StaffUnitSearchSettingsPowerForm({
                                                studentOptions: filters.studentOptions,
                                                applicationStateOptions: filters.applicationStatusOptions,
                                                studentOfficeOptions: filters.studentOfficeOptions
                                            });
                                        }
                                        return (
                                            <div class={classNames("card-body", hidePanel ? "text-center" : "")}>
                                                {hidePanel
                                                    ? <Spinner />
                                                    : (
                                                        <StaffDecisionSearchSettingsPanel
                                                            form={state.inboxSearchSettingsForm}
                                                            onSubmit={handleSearchSettingsChanged}
                                                        />
                                                    )
                                                }
                                            </div>
                                        );
                                    }}
                                />
                            </div>
                            <div class="card bg-light mt-3 mb-3">
                                <div class="card-header">Inbox</div>
                                <PersistentDataLoader
                                    id="staff-page-inbox"
                                    settings={state.inboxSearchSettings}
                                    requests={{inbox: ({settings}) => fetchInbox(settings)}}
                                    render={({ loading, error, refresh, data: { inbox } = {}}) => (
                                        <div class={classNames("card-body", loading ? "text-center" : "")}>
                                            {loading
                                                ? <Spinner />
                                                : <InboxTable data={inbox} refresh={refresh} />
                                            }
                                        </div>
                                    )}
                                />
                            </div>
                        </div>
                    </div>
                </div>
            </Layout>
        );
    }

    return { view };
}
