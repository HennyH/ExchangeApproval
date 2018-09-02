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
    }

    function view({ attrs: { id , decisions }}) {
        maybeRefresh(decisions);
        return (
            <div>
                <table id={id} class="display table compact" style="width:100%" />
            </div>
        )
    }

    function oncreate({ attrs: { id, decisions }}) {
        datatable = $("#" + id).DataTable({
            data: decisions,
            columns: [
                { title: "Decision Date", data: "decision_date" },
                { title: "Approval Type", data: "uwa_unit_context_name" },
                { title: "Ex. University", data: "exchange_university_name" },
                { title: "Ex. Unit Name", data: "exchange_unit_name" },
                { title: "Ex. Unit Code", data: "exchange_unit_code" },
                { title: "Ex. Outline", data: "exchange_unit_outline_href" },
                { title: "UWA Unit Name", data: "uwa_unit_name" },
                { title: "UWA Unit Code", data: "uwa_unit_code" },
                { title: "Approved", data: "approved" }
            ]
        });
    }

    return { view, oncreate };
}