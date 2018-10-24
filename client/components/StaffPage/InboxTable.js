import m from 'mithril'

import DataTable from 'Components/DataTable/DataTable.js';
import { ModalState } from '../ViewData';
import DataLoader from 'Components/DataLoader.js'
import ApplicationForm, { ApplicationPowerForm } from 'Components/ApplicationPage/ApplicationForm.js'
import Spinner from 'Components/Spinners/RectangularSpinner.js';
import Modal from '../Modal/Modal.js';
import { EmailData } from '../ViewData.js';

const noop = () => {};

export const COLUMN_NAMES = {
    Id: 'Id',
    StudentName: "Student Name",
    StudentNumber: "Student Number",
    Date: 'Date',
    Type: 'Type',
    ExchangeUniversityName: 'Ex. University',
    Approved: 'Appv.',
    Edit: 'Edit'
};

export function makeInboxTableConfig(decisions) {
    return {
        data: decisions,
        columns: [
            {
                title: COLUMN_NAMES.StudentName,
                data: "studentName"
            },
            {
                title: COLUMN_NAMES.StudentNumber,
                data: "studentNumber"
            },
            {
                title: COLUMN_NAMES.Date,
                data: "lastUpdatedAt",
                render: (data, type, row, meta) => {
                    if (data === null) {
                        return `
                            <span class='badge badge-warning'>
                                PENDING
                            </span>
                        `;
                    }
                    const options = { month: "short", year: "2-digit" };
                    return new Date(data).toLocaleDateString(undefined, options);
                }
            },
            {
                title: COLUMN_NAMES.ExchangeUniversityName,
                data: "exchangeUniversityName",
                width: '30%',
                render: (data, type, row, meta) =>
                `<a href=${encodeURI(row.exchangeUniversityHref)} target="_blank">${data}</a>`
            },
            {
                title: COLUMN_NAMES.Approved,
                data: "studentApplicationStatus",
                render: (data, type, row, meta) => data.label
            },
            {
                title: COLUMN_NAMES.Edit,
                render: (data, type, row, meta) =>
                    `<button type='button' class='btn btn-primary'>🖉 Edit</button>`
            }
        ]
    }
}

function StaffEditApplicationModal() {

    const state = { applicationForm: null };

    function fetchApplication(applicationId) {
        const qs = m.buildQueryString({ id: applicationId });
        return m.request(`/api/application?${qs}`);
    }

    function submitAppliction() {
        console.log(state.applicationForm.getData());
        m.request({
            method: "POST",
            url: "/api/application/update",
            data: state.applicationForm.getData()
        });
    }

    function view({ attrs: { applicationId, onClose = noop } }) {
        const editApplicationModalFooter = ([
                <div>
                    <button type="button" class="btn btn-outline-primary mx-1" onclick={() => EmailData.Student.SendEmail()}>
                        Send Application Results
                    </button>
                    <button type="button" class="btn btn-outline-secondary mx-1" onclick={() => EmailData.Student.CopyText()}>
                        Copy to Clipboard
                    </button>
                </div>,
                <div>
                    <button type="button" class="btn btn-secondary mx-1" data-dismiss="modal">
                        Cancel
                    </button>
                    <button type="button" class="btn btn-primary mx-1" data-dismiss="modal" onclick={submitAppliction}>
                        Save Application
                    </button>
                </div>
        ]);
        return (
            <DataLoader
                applicationId={applicationId}
                requests={{
                    application: ({ applicationId }) => fetchApplication(applicationId),
                    filters: () => m.request("/api/filters/staff")
                }}
                render={({ loading, errored, data: { application, filters } = {} }) => {
                    const showLoading = loading || errored;
                    if (state.applicationForm === null && !showLoading) {
                        state.applicationForm = new ApplicationPowerForm({
                            unitLevelOptions: filters.unitLevelOptions,
                            studentOfficeOptions: filters.studentOfficeOptions,
                        });
                        state.applicationForm.setData(application);
                    }
                    console.log("rendering modal");
                    return applicationId && (
                        <Modal
                            size="xl"
                            title="Edit Application"
                            footer={editApplicationModalFooter}
                            onClose={() => {
                                state.applicationForm = null;
                                onClose();
                            }}
                        >
                            {(showLoading
                                ? <Spinner />
                                : <ApplicationForm form={state.applicationForm} staffView={true} />
                            )}
                        </Modal>
                    );
                }}
            />
        );
    }

    return { view };
}

export default function InboxTable() {

    const state = { selectedApplicationId: null };

    function view({ attrs: { data }}) {
        return (
            <div>
                <DataTable
                    id="inbox-table"
                    config={makeInboxTableConfig(data)}
                    setup={(id, datatable) => {
                        $(`#${id} tbody`).on('click', 'button', (event) => {
                            const inboxItem = datatable.row($(event.target).parents('tr')).data();
                            state.selectedApplicationId = inboxItem.studentApplicationId;
                            m.redraw();
                        });
                    }}
                    cache={false}
                />
                {state.selectedApplicationId && (
                    <StaffEditApplicationModal
                        applicationId={state.selectedApplicationId}
                        onClose={() => {
                            state.selectedApplicationId = null;
                        }}
                    />
                )}
            </div>
        )
    }

    return { view }
}