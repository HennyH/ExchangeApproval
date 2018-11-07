import m from 'mithril'

window.NEXT_DATA_TABLE_ID = 1;
window.TABLE_ID_TO_DATA = {};
window.TABLE_ID_TO_DATATABLE = {};

export default function DataTable() {

    let id = null;
    let isCacheEnabled = false;

    function getDataTable() {
        return id ? window.TABLE_ID_TO_DATATABLE[id] : null;
    }

    function setDataTable(datatable) {
        window.TABLE_ID_TO_DATATABLE[id] = datatable;
    }

    function getData() {
        return id ? window.TABLE_ID_TO_DATA[id] : [];
    }

    function setData(data) {
        window.TABLE_ID_TO_DATA[id] = data;
    }

    function maybeRefreshData(newData) {
        /* If the data hasn't changed (we treat it as an immutable list
         * since fetching the data from the API would result in a new list)
         * don't rerender the datatable. This operation can take almost 800ms.
         */
        const datatable = getDataTable();
        if (newData === getData() || datatable === null || datatable === undefined) {
            return;
        }

        datatable.clear();
        datatable.rows.add(newData);
        datatable.draw();
        setData(newData);
    }

    function oninit({ attrs: { id: providedId, cache = false }}) {
        id = providedId || `datatable-${(window.NEXT_DATA_TABLE_ID++)}`;
        if (cache) {
            if (!providedId) {
                throw Error("You must specify and id to when enabling caching.");
            }
            isCacheEnabled = true;
        }
    }

    function view({ attrs: { config: { data } } }) {
        maybeRefreshData(data);
        return (
            <div id={`data-table-anchor-${id}`} style="display: none" />
        )
    }

    function oncreate({ attrs: { config, setup = null }, dom: ref }) {
        const $anchor = $(ref);
        let rehydratedFromCache = false;

        if (isCacheEnabled) {
            const $maybeCachedTable = $(`#_table_wrapper_${id}`);
            if ($maybeCachedTable.length > 0) {
                $maybeCachedTable.insertAfter($anchor);
                rehydratedFromCache = true;
            }
        }

        if (!rehydratedFromCache) {
            $anchor.after(`
                <div id="_table_wrapper_${id}">
                    <table id="_table_${id}" class="display table compact" style="width:100%"></table>
                </div>
            `);
            const datatable = $(`#_table_${id}`).DataTable({
                ...config,
                /* Override the data here. We do this because the maybeRefresh
                    * function updates some internal state about what data we
                    * are displaying so as to avoid expensive re-renders when
                    * the data doesn't change, we'll call it in a moment.
                    */
                data: []
            });
            setDataTable(datatable);
        }

        maybeRefreshData(config.data);

        if (!rehydratedFromCache && setup) {
            setup($(`#_table_${id}`), getDataTable(), config);
        }

        const { page } = getDataTable().page.info();
        setTimeout(() => {
            getDataTable().page(page);
        }, 3000)
    }

    function onremove({ dom : ref }) {
        if (isCacheEnabled) {
            if ($("#data-table-cache").length === 0) {
               $("<div id='data-table-cache' style='display: none' />").appendTo(document.body);
            }
            const cache = $("#data-table-cache");
            const table = $(`#_table_wrapper_${id}`);
            table.appendTo(cache);
        } else {
            setData(null);
            setDataTable(null);
            /* clear out our unmanaged DOM */
            $(ref).siblings().remove();
        }
    }

    return { oninit, view, oncreate, onremove };
}