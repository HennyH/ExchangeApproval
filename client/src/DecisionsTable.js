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
                <table id={id} class="display table" style="width:100%" />
            </div>
        )
    }

    function oncreate({ attrs: { id, decisions }}) {
        datatable = $("#" + id).DataTable({
            data: decisions,
            columns: [
                { title: 'Unit Name', data: 'exchange_unit_name' }
            ]
        });
    }

    return { view, oncreate };
}