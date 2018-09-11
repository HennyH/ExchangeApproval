import m from 'mithril'

import DataTable from 'Components/DataTable';
import Styles from './DecisionsTable.css'

export const COLUMN_NAMES = {
    Date: 'Date',
    Type: 'Type',
    ExchangeUniversity: 'Ex. University',
    ExchangeUnit: 'Ex. Unit(s)',
    UWAUnit: 'UWA Unit(s)',
    Approved: 'Appv.',
    Cart: 'Cart'
};

export function makeDecisionsTableConfig(decisions, headers) {
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
                title: COLUMN_NAMES.Date,
                data: "approvedAt",
                render: (data, type, row, meta) => {
                    const options = { month: "short", year: "2-digit" };
                    return new Date(data).toLocaleDateString(undefined, options);
                }
            },
            {
                title: COLUMN_NAMES.ExchangeUniversity,
                data: "exchangeUniversityName",
                width: '30%',
                render: (data, type, row, meta) =>
                    `<a href="${encodeURI(row.exchangeUniversityHref)}">${data}</a>`
            },
            {
                title: COLUMN_NAMES.ExchangeUnit,
                width: "30%",
                data: "exchangeUnits",
                render: (data, type, row, meta) =>
                    data.map(u =>
                        `
                        <a class="badge badge-secondary" href="${u.unitHref}">
                            ${u.unitName}
                            <span class="badge badge-light">${u.unitCode}</span>
                        </a>
                        `
                    ).join('')
            },
            {
                title: COLUMN_NAMES.UWAUnit,
                data: "uwaUnits",
                width: "30%",
                render: (data, type, row, meta) =>
                    data.map(u =>
                        `
                        <a class="badge badge-secondary" href="${u.unitHref}">
                            ${u.unitName}
                            <span class="badge badge-light">${u.unitCode}</span>
                            <span class="badge ${TYPE_TO_BADGE_CLASS[u.uwaUnitContext.label]}">
                                ${u.uwaUnitContext.label}
                            </span>
                        </a>
                        `
                    ).join('')
            },
            {
                title: COLUMN_NAMES.Approved,
                data: "approved",
                render: (data, type, row, meta) => data ? "✅" : data == null ? "💭" : "❌"
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