import m from 'mithril'

import DataTable from 'Components/DataTable';
import Styles from './DecisionsTable.css'

export const COLUMN_NAMES = {
    Date: 'Date',
    Type: 'Type',
    ExchangeUniversity: 'Exchange University',
    ExchangeUnit: 'Exchange Unit(s)',
    UWAUnit: 'UWA Unit(s)',
    Approved: 'Appvoved',
    Cart: 'Cart'
};

export function makeDecisionsTableConfig(decisions, headers) {
    const TYPE_TO_BADGE_CLASS = {
        Elective: 'badge-warning',
        Complementary: 'badge-primary',
        Core: 'badge-success'
    }
    const DEFAULT_BADGE_CLASS = 'badge-secondary';

    const unitButton = ({ unitName, unitCode, unitHref }) => {
        return
            `
            <div class="btn-group" role="group">
                <button
                    type="button"
                    rel="tooltip"
                    class="has-popover btn btn-secondary"
                    data-toggle="tooltip"
                    data-placement="top"
                    title="${unitName}"
                >
                    ${unitCode}
                </button>
                <a href="${unitHref}" role="button" class="btn btn-link">
                    🌐
                </a>
            </div>
            `
    }

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
                render: (data, type, row, meta) => data.map((u, i) =>
                    `
                    <span class="badge badge-secondary ${i > 0 ? 'mt-1' : '' }" style="line-height: 2em; padding-left: 0.7em; padding-right: 0.7em;">
                        <span
                            rel="popover"
                            data-toggle="tooltip"
                            data-placement="top"
                            title="${u.unitName}"
                        >
                            ${u.unitCode}
                        </span>
                        <a href="${u.unitHref}" class="badge badge-light" style="font-size: 100%; margin-left: 0.5em">
                            ↪
                        </a>
                    </span>
                    `
                ).join('')
            },
            {
                title: COLUMN_NAMES.UWAUnit,
                data: "uwaUnits",
                width: "30%",
                render: (data, type, row, meta) => data.map((u, i) =>
                    `
                    <span class="badge badge-secondary  ${i > 0 ? 'mt-1' : '' }" style="line-height: 2em; padding-left: 0.7em; padding-right: 0.7em;">
                        <span
                            rel="popover"
                            data-toggle="tooltip"
                            data-placement="top"
                            title="${u.unitName}"
                        >
                            ${u.unitCode}
                        </span>
                        <a href="${u.unitHref}" class="badge badge-light" style="font-size: 100%; margin-left: 0.5em">
                            ↪
                        </a>
                    </span>
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
                    });
                    $(`#${id} tbody`).tooltip({
                        selector: '[rel="popover"]',
                        trigger: 'hover'
                    });
                }}
                cache={true}
            />
        )
    }

    return { view }
}