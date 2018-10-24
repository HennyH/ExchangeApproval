import m from 'mithril'

import DataTable from 'Components/DataTable/DataTable.js';
import { ModalState } from '../ViewData';
import DataLoader from 'Components/DataLoader.js'
import ApplicationForm, { ApplicationPowerForm } from 'Components/ApplicationPage/ApplicationForm.js'
import Spinner from 'Components/Spinners/RectangularSpinner.js';
import Modal from '../Modal/Modal.js';
import { EmailData } from '../ViewData.js';
import Styles from './InboxTable.css';

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

    const state = {
        applicationForm: null,
        modalRef: null
    };

    function fetchApplication(applicationId) {
        const qs = m.buildQueryString({ id: applicationId });
        return m.request(`/api/application?${qs}`);
    }

    function submitAppliction(onSubmit, onClose) {
        state.submittingApplication = true;
        m.request({
            method: "POST",
            url: "/api/application/update",
            data: state.applicationForm.getData()
        })
        .then(async () => {
            if (state.modalRef) {
                state.modalRef.modal('hide');
            }
            await onSubmit();
            return onClose();
        });

    }

    function view({ attrs: { applicationId, onSubmit = noop, onClose = noop } }) {
        return (
            <DataLoader
                applicationId={applicationId}
                requests={{
                    application: ({ applicationId }) => fetchApplication(applicationId),
                    filters: () => m.request("/api/filters/staff")
                }}
                render={({ loading, errored, data: { application, filters } = {} }) => {
                    const showLoading = !!(loading || errored);
                    if (state.applicationForm === null && !showLoading) {
                        state.applicationForm = new ApplicationPowerForm({
                            unitLevelOptions: filters.uwaUnitLevelOptions,
                            studentOfficeOptions: filters.studentOfficeOptions,
                        });
                        state.applicationForm.setData(application);
                    }
                    const modalFooter = ([
                        <div>
                            <button disabled={showLoading} type="button" class="btn btn-outline-primary mx-1" onclick={() => EmailData.Student.SendEmail()}>
                                Send Application Results
                            </button>
                            <button disabled={showLoading} type="button" class="btn btn-outline-secondary mx-1" onclick={() => EmailData.Student.CopyText()}>
                                Copy to Clipboard
                            </button>
                        </div>,
                        <div>
                            <button type="button" class="btn btn-secondary mx-1" data-dismiss="modal">
                                Cancel
                            </button>
                            <button disabled={showLoading} type="button" class="btn btn-primary mx-1" onclick={() => submitAppliction(onSubmit, onClose)}>
                                Save Application
                            </button>
                        </div>
                    ]);
                    return applicationId && (
                        <Modal
                            size="xl"
                            title="Edit Application"
                            footer={modalFooter}
                            onClose={() => {
                                state.applicationForm = null;
                                onClose();
                            }}
                            ref={(ref) => {
                                state.modalRef = ref;
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

    const state = {
        inboxDatatable: null,
        selectedInboxApplicationId: null,
        selectedInboxRow: null
    };

    function view({ attrs: { data }}) {
        return (
            <div>
                <DataTable
                    id="inbox-table"
                    config={makeInboxTableConfig(data)}
                    setup={(id, datatable) => {
                        state.inboxDatatable = datatable;
                        $(`#${id} tbody`).on('click', 'button', (event) => {
                            const row = $(event.target).parents('tr');
                            state.selectedInboxRow = row;
                            state.selectedInboxApplicationId = datatable.row(row).data().studentApplicationId;
                            m.redraw();
                        });
                    }}
                    cache={false}
                />
                {state.selectedInboxApplicationId && (
                    <StaffEditApplicationModal
                        applicationId={state.selectedInboxApplicationId}
                        onSubmit={() => {
                            const qs = m.buildQueryString({
                                applicationId: state.selectedInboxApplicationId
                            });
                            m.request(`/api/inbox/application?${qs}`).then((inboxItem) => {
                                if (state.selectedInboxRow) {
                                    state.inboxDatatable.row(state.selectedInboxRow).data(inboxItem).invalidate();
                                    state.selectedInboxRow.addClass(Styles.blink);
                                }
                            });
                        }}
                        onClose={() => {
                            state.selectedInboxApplicationId = null;
                        }}
                    />
                )}
            </div>
        )
    }

    return { view }
}