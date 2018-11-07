import m from 'mithril'

import DataTable from 'Components/DataTable';
import Styles from './DecisionsTable.css'

export const COLUMN_NAMES = {
    Date: 'Date',
    Type: 'Type',
    ExchangeUniversity: 'Exchange University',
    ExchangeUnit: 'Exchange Unit(s)',
    UWAUnit: 'UWA Unit(s)',
    Approved: 'Approved',
    Cart: 'Add'
};

export function makeDecisionsTableConfig(decisions, headers) {
    const unitButton = ({
        displayName,
        tooltipContent,
        href,
        badgeType = "secondary",
        badgeClasses = ""
    }) => {
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
                    style="width: 100%; white-space: nowrap; overflow: hidden; text-overflow: ellipsis"
                >
                    ${displayName || ""}
                </span>
                ${link}
            </span>
        `;
    }

    return {
        data: decisions,
        responsive: {
            details: {
                display: $.fn.dataTable.Responsive.display.childRowImmediate,
                renderer: function ( api, rowIdx, columns ) {
                var data = $.map( columns, function ( col, i ) {
                    return col.hidden ?
                        '<tr data-dt-row="'+col.rowIndex+'" data-dt-column="'+col.columnIndex+'">'+
                            '<td>'+col.title+':'+'</td> '+
                            '<td>'+col.data+'</td>'+
                        '</tr>' :
                        '';
                } ).join('');

                return data ?
                    $('<table class="table"/>').append( data ) :
                    false;
            }
            }
        },
        columns: [
            {
                title: COLUMN_NAMES.ExchangeUniversity,
                responsivePriority: 1,
                data: "exchangeUniversityName",
                width: '30%',
                render: (data, type, row, meta) =>
                    `<a href="${encodeURI(row.exchangeUniversityHref)}" target="_blank">${data}</a>`
            },
            {
                title: COLUMN_NAMES.ExchangeUnit,
                responsivePriority: 2,
                width: "30%",
                data: "exchangeUnits",
                render: (data, type, row, meta) => data.map((u, i) => unitButton({
                    displayName: u.unitName || u.unitCode,
                    tooltipContent: `${u.unitName} ${u.unitCode}`,
                    href: u.unitHref,
                    badgeClasses: i > 0 ? 'mt-1' : ''
                })).join('')
            },
            {
                title: COLUMN_NAMES.UWAUnit,
                responsivePriority: 3,
                width: "30%",
                data: "uwaUnits",
                render: (data, type, row, meta) => {
                    return [
                        ...row.uwaUnits.map((u, i) => unitButton({
                            displayName: u.unitCode || u.unitName,
                            tooltipContent: `${u.unitName} ${u.unitCode}`,
                            href: u.unitHref,
                            badgeClasses: i > 0 ? 'mt-1' : ''
                        })),
                        unitButton({
                            displayName: `Level ${row.equivalentUnitLevel.label}`,
                            tooltipContent: `Was deemed equivalent of a level ${row.equivalentUnitLevel.label} unit.`,
                            badgeType: 'primary'
                        })
                    ].join('');
                }
            },
            {
                title: COLUMN_NAMES.Approved,
                responsivePriority: 4,
                data: "approved",
                render: (data, type, row, meta) => `
                    <div style="display: inline; width: 100%; height: 100%; padding-right: 0px; text-align: center; padding-right: 0.75rem">
                        ${data ? "✅" : "❌"}
                    </div>
                `
            },
            !window.LOGGED_IN && {
                title: COLUMN_NAMES.Cart,
                responsivePriority: 5,
                data: null,
                render: (data, type, row, meta) => {
                    return row.approved
                        ? "<button type='button' class='btn btn-outline-secondary'>🛒</button>"
                        : ""
                }
            }
        ].filter(c => c && (headers == null || headers.includes(c.title)))
    }
}

export default function DecisionsTable() {

    function view({ attrs: { decisions, onAddToCart, headers = null } }) {
        return (
            <DataTable
                id="decisions-table"
                config={makeDecisionsTableConfig(decisions, headers)}
                setup={($ref, datatable) => {
                    $ref.on('click', 'button', function (event) {
                        const decision = datatable.row($(event.target).parents('tr')).data();
                        onAddToCart(decision);
                    });
                    $ref.tooltip({
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