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
                title: COLUMN_NAMES.Id,
                data: "id"
            },
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
                data: "decisionDate",
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
                data: "approved",
                render: (data, type, row, meta) => data ? "✅" : data == null ? "💭" : "❌"
            },
            {
                title: COLUMN_NAMES.Edit,
                render: (data, type, row, meta) => {
                    return row.approved === null
                        ? `<button type='button' class='btn btn-primary'>🖉 Edit</button>`
                        : `<button type='button' class='btn btn-secondary' disabled>⚿ Edit</button>`
                }
            }
        ]
    }
}

export default function InboxTable() {

    function view({ attrs: { decisions }}) {
		
		return (
            <DataTable
                id="inbox-table"
                config={makeInboxTableConfig(decisions)}
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