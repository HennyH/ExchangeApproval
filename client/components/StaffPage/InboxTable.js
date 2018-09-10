import m from 'mithril'

import DataTable from 'Components/DataTable/DataTable.js';
import Styles from '../SearchPage/DecisionsTable.css'

export const COLUMN_NAMES = {
    Id: 'Id',
    Date: 'Date',
    Type: 'Type',
    ExchangeUniversity: 'Ex. University',
    ExchangeUnit: 'Ex. Unit',
    UWAUnit: 'UWA Unit',
    Approved: 'Appv.'
};

export function makeInboxTableConfig(decisions, headers) {
    const TYPE_TO_BADGE_CLASS = {
        Elective: 'badge-warning',
        Complementary: 'badge-primary',
        Core: 'badge-success'
    }
    const DEFAULT_BADGE_CLASS = 'badge-secondary';

    return {
        data: decisions,
        columns: [
            {
                title: COLUMN_NAMES.Id,
                data: "id",
                render: (data, type, row, meta) => data
            },
            {
                title: COLUMN_NAMES.Date,
                data: "decisionDate",
                render: (data, type, row, meta) => {
                    const options = { month: "short", year: "2-digit" };
                    return new Date(data).toLocaleDateString(undefined, options);
                }
            },
            {
                title: COLUMN_NAMES.Type,
                data: "uwaUnitContext",
                render: (data, type, row, meta) => `
                    <span class='badge ${TYPE_TO_BADGE_CLASS[data] || DEFAULT_BADGE_CLASS} ${Styles.contextTypeBadge}'>
                        ${data.substring(0, 4).toUpperCase()}
                    </span>
                `
            },
            {
                title: COLUMN_NAMES.ExchangeUniversity,
                data: "exchangeUniversityName",
                width: '30%'
            },
            {
                title: COLUMN_NAMES.ExchangeUnit,
                width: "30%",
                data: "exchangeUnitName",
                render: (data, type, row, meta) => `<a href=${encodeURI(data.exchangeUnitOutlineHref)}>${data} (${row.exchangeUnitCode})</a>`

            },
            {
                title: COLUMN_NAMES.UWAUnit,
                data: null,
                width: "30%",
                render: (data, type, row, meta) => {
                    const components = [
                        row.uwaUnitName || '',
                        row.uwaUnitCode ? `(${row.uwaUnitCode})` : ''
                    ];
                    return components.join(' ');
                }
            },
            {
                title: COLUMN_NAMES.Approved,
                data: "approved",
                render: (data, type, row, meta) => data ? "✅" : data == null ? "💭" : "❌"
            }
        ].filter(c => headers == null || headers.includes(c.title))
    }
}

export default function InboxTable() {

    function view({ attrs: { decisions, headers = null }}) {
        return (
            <DataTable
                id="inbox-table"
                config={makeInboxTableConfig(decisions, headers)}
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