import m from 'mithril'

import DataTable from 'Components/DataTable/DataTable.js';
import { ModalState } from '../ViewData';
import DataLoader from 'Components/DataLoader.js'
import ApplicationForm, { ApplicationPowerForm } from 'Components/ApplicationPage/ApplicationForm.js'
import Spinner from 'Components/Spinners/RectangularSpinner.js';
import Modal from '../Modal/Modal.js';
import { EmailData } from '../ViewData.js';

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

export default function InboxTable() {

    const state = {
        applicationId: null,
        applicationForm: null
    };

    function view({ attrs: { data }}) {

        return (
            <div>
                <DataTable
                    id="inbox-table"
                    config={makeInboxTableConfig(data)}
                    setup={(id, datatable) => {
                        $(`#${id} tbody`).on('click', 'button', (event) => {
                            const inboxItem = datatable.row($(event.target).parents('tr')).data();
                            state.applicationId = inboxItem.studentApplicationId;
                            m.redraw();
                        });
                    }}
                    cache={false}
                />
                <DataLoader
                    application={state.applicationId}
                    requests={{
                        application: ({ application }) => m.request("/api/application?id=1"),
                        filters: () => m.request("/api/filters/staff")
                    }}
                    render={({ loading, errored, data: { application, filters } = {} }) => {
                        if (loading || errored) {
                            return <Spinner />;
                        }
                        if (state.applicationForm == null) {
                            state.applicationForm = new ApplicationPowerForm({
                                unitLevelOptions: filters.unitLevelOptions,
                                studentOfficeOptions: filters.studentOfficeOptions,
                            });
                            state.applicationForm.setData(application);
                        }
                        return (
                            <Modal size = {"xl"}>
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h5 class="modal-title" id="ModalTitle">Edit Application</h5>
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                            <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
                                    <div class="modal-body p-0">
                                        <ApplicationForm form={state.applicationForm} staffView={true} />
                                    </div>
                                    <div class="modal-footer d-flex justify-content-between">
                                        <div>
                                            <button type="button" class="btn btn-outline-primary mx-1" onclick={() => EmailData.Student.SendEmail()}>
                                                Send Application Results
                                            </button>
                                            <button type="button" class="btn btn-outline-secondary mx-1" onclick={() => EmailData.Student.CopyText()}>
                                                Copy to Clipboard
                                            </button>
                                        </div>
                                        <div>
                                            <button type="button" class="btn btn-secondary mx-1" data-dismiss="modal">Cancel</button>
                                            <button type="button" class="btn btn-primary mx-1" data-dismiss="modal">Save Application</button>
                                        </div>
                                    </div>
                                </div>
                            </Modal>
                        );
                    }}
                />
            </div>
        )
    }

    return { view }
}