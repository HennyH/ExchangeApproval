import m from 'mithril'

import DataTable from 'Components/DataTable/DataTable.js';
import Styles from '../SearchPage/DecisionsTable.css'
import { ModalState } from '../ViewData';

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

    function view({ attrs: { data }}) {

        return (
            <DataTable
                id="inbox-table"
                config={makeInboxTableConfig(data)}
                setup={(id, datatable) => {
                    $(`#${id} tbody`).on('click', 'button', function(event) {
                        const decision = datatable.row($(event.target).parents('tr')).data();
                        ModalState.ApplicationModal.show(decision);
                    })
                }}
                cache={false}
            />
        )
    }

    return { view }
}