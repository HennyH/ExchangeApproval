import m from 'mithril'

export default function DecisionsTable() {

    let oldDecisions = null;
    let datatable = null;

    function maybeRefresh(newDecisions) {
        if (newDecisions === oldDecisions || datatable === null) {
            return;
        }

        datatable.clear();
        datatable.rows.add(newDecisions);
        datatable.draw();

        oldDecisions = newDecisions;
    }

    function view({ attrs: { id , decisions }}) {
        maybeRefresh(decisions);
        return (
            <div>
                <table id={id} class="display table compact" style="width:100%" />
            </div>
        )
    }

    function oncreate({ attrs: { id, decisions, config }}) {
        datatable = $("#" + id).DataTable({
            data: decisions,
            columns: [
                {
                    title: "Date",
                    data: "decision_date",
                    render: (data, type, row, meta) => {
                        const options = { month: "short", year: "2-digit" };
                        return new Date(data).toLocaleDateString(undefined, options);
                    } },
                {
                    title: "Type",
                    data: "uwa_unit_context_name",
                    render: (data, type, row, meta) => {
                        if (data === "Elective") {
                            return "<span class='badge badge-warning'>elec</span>";
                        } else if (data === "Complementary") {
                            return "<span class='badge badge-primary'>comp</span>";
                        } else if (data === "Core") {
                            return "<span class='badge badge-success'>core</span>";
                        }

                        return `<span class='badge badge-secondary'>${data}</span>`;
                    }
                },
                {
                    title: "Ex. Uni",
                    data: "exchange_university_name",
                    width: '30%'
                },
                {
                    title: "Ex. Unit",
                    width: "30%",
                    data: "exchange_unit_name",
                    render: (data, type, row, meta) => {
                        return `<a href=${encodeURI(data.exchange_unit_outline_href)}>${data} (${row.exchange_unit_code})</a>`;
                    }
                },
                {
                    title: "UWA Unit",
                    data: null,
                    width: "30%",
                    render: (data, type, row, meta) => {
                        const components = [
                            row.uwa_unit_name || '',
                            row.uwa_unit_code ? `(${row.uwa_unit_code})` : ''
                        ];
                        return components.join(' ');
                    }
                },
                {
                    title: "Apprv.",
                    data: "approved",
                    render: (data, type, row, meta) => {
                        if (data) {
                            return "✅";
                        } else {
                            return "❌";
                        }
                    }
                },
                {
                    title: "Cart",
                    data: null,
                    defaultContent: "<button type='button' class='btn btn-primary'>🛒</button>"
                }
            ]
        });

        $(`#${id} tbody`).on('click', 'button', function(event) {
            const decision = datatable.row($(event.target).parents('tr')).data();
            console.log(decision);
        })
    }

    return { view, oncreate };
}