import m from 'mithril'

import DataTable from 'Components/DataTable/DataTable.js';
import Styles from '../SearchPage/DecisionsTable.css'

export const COLUMN_NAMES = {
    Id: 'Id',
    StudentName: "Student Name",
    StudentNumber: "Student Number",
    Date: 'Date',
    Type: 'Type',
    ExchangeUniversityName: 'Ex. University',
    Approved: 'Appv.'
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
                `<a href=${encodeURI(row.exchangeUniversityHref)}>${data}</a>`
            },
            {
                title: COLUMN_NAMES.Approved,
                data: "approved",
                render: (data, type, row, meta) => data ? "✅" : data == null ? "💭" : "❌"
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
                    })
                }}
                cache={true}
            />
        )
    }

    return { view }
}