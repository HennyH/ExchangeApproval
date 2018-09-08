import m from 'mithril'

import DataTable from 'Components/DataTable';
import Styles from './DecisionsTable.css'

export const COLUMN_NAMES = {
    Date: 'Date',
    Type: 'Type',
    ExchangeUniversity: 'Ex. University',
    ExchangeUnit: 'Ex. Unit',
    UWAUnit: 'UWA Unit',
    Approved: 'Appv.',
    Cart: 'Cart'
};

export function makeDecisionsTableConfig(decisons, headers) {
    const TYPE_TO_BADGE_CLASS = {
        Elective: 'badge-warning',
        Complementary: 'badge-primary',
        Core: 'badge-success'
    }
    const DEFAULT_BADGE_CLASS = 'badge-secondary';

    return {
        data: decisons,
        columns: [
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
                render: (data, type, row, meta) => data ? "✅" : "❌"
            },
            {
                title: COLUMN_NAMES.Cart,
                data: null,
                render: (data, type, row, meta) => {
                    return row.approved
                        ? "<button type='button' class='btn btn-primary'>🛒</button>"
                        : ""
                }
            }
        ].filter(c => headers == null || headers.includes(c.title))
    }
}

export default function DecisionsTable() {

    function view({ attrs: { decisions, onAddToCart, headers = null }}) {
        return (
            <DataTable
                id="decisions-table"
                config={makeDecisionsTableConfig(decisions, headers)}
                setup={(id, datatable) => {
                    $(`#${id} tbody`).on('click', 'button', function(event) {
                        const decision = datatable.row($(event.target).parents('tr')).data();
                        onAddToCart(decision);
                    })
                }}
                cache={true}
            />
        )
    }

    return { view }
}