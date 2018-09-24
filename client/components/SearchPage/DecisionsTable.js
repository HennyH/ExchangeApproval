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
    const unitButton = ({
        displayName,
        tooltipContent,
        href,
        badgeType = "secondary",
        badgeClasses = ""
    }) => {
        displayName = displayName || "";
        const shortName = displayName.length >= 20
            ? displayName.substring(0, 18) + "..."
            : displayName;
        const link = href
            ? `
                <a href="${href}" class="badge badge-light" style="font-size: 100%; margin-left: 0.5em" target="_blank">
                    ↪
                </a>
            `
            : ``;
        return `
            <span class="badge badge-${badgeType} ${badgeClasses}" style="line-height: 2em; padding-left: 0.7em; padding-right: 0.7em;">
                <span
                    rel="popover"
                    data-toggle="tooltip"
                    data-placement="top"
                    title="${tooltipContent}"
                >
                    ${shortName}
                </span>
                ${link}
            </span>
        `;
    }

    return {
        data: decisions,
        columns: [
            {
                title: COLUMN_NAMES.Date,
                data: "lastUpdatedAt",
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
                    `<a href="${encodeURI(row.exchangeUniversityHref)}" target="_blank">${data}</a>`
            },
            {
                title: COLUMN_NAMES.ExchangeUnit,
                width: "30%",
                data: "exchangeUnits",
                render: (data, type, row, meta) => data.map((u, i) => unitButton({
                    displayName: u.unitCode || u.unitName,
                    tooltipContent: `${u.unitName} ${u.unitCode}`,
                    href: u.unitHref,
                    badgeClasses: i > 0 ? 'mt-1' : ''
                })).join('')
            },
            {
                title: COLUMN_NAMES.UWAUnit,
                width: "30%",
                render: (data, type, row, meta) => {
                    if (row.uwaUnits === null || row.uwaUnits === undefined || row.uwaUnits.length == 0) {
                        return unitButton({
                            displayName: `Level ${row.equivalentUnitLevel.label}`,
                            tooltipContent: `Was deemed equivalent of a level ${row.equivalentUnitLevel.label} unit.`,
                            badgeType: 'primary'
                        });
                    }
                    return row.uwaUnits.map((u, i) => unitButton({
                        displayName: u.unitCode || u.unitName,
                        tooltipContent: `${u.unitName} ${u.unitCode}`,
                        href: u.unitHref,
                        badgeClasses: i > 0 ? 'mt-1' : ''
                    })).join('');
                }
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
                cache={false}
            />
        )
    }

    return { view }
}