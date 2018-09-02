import m from 'mithril'

window.NEXT_DATA_TABLE_ID = 1;

export default function DataTable() {

    let id = null;
    let oldData = null;
    let datatable = null;

    function maybeRefresh(newData) {
        /* If the data hasn't changed (we treat it as an immutable list
         * since fetching the data from the API would result in a new list)
         * don't rerender the datatable. This operation can take almost 800ms.
         */
        if (newData === oldData || datatable === null) {
            return;
        }

        datatable.clear();
        datatable.rows.add(newData);
        datatable.draw();
        oldData = newData;
    }

    function oninit({ attrs: { id: providedId }}) {
        id = providedId || `datatable-${(window.NEXT_DATA_TABLE_ID++)}`;
    }

    function view({ attrs: { config: { data } } }) {
        maybeRefresh(data);
        return (
            <div>
                <table id={id} class="display table compact" style="width:100%" />
            </div>
        )
    }

    function oncreate({ attrs: { config, setup = null }}) {
        datatable = $("#" + id).DataTable(config);
        if (setup) {
            setup(id, datatable, config);
        }

    }

    return { oninit, view, oncreate };
}