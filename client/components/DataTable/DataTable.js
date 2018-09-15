import m from 'mithril'

window.NEXT_DATA_TABLE_ID = 1;
window.TABLE_ID_TO_DATA = {};
window.TABLE_ID_TO_DATATABLE = {};

export default function DataTable() {

    let id = null;
    let isCacheEnabled = false;
    let refreshLock = true;

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
        if (newData === getData() || datatable === null || datatable === undefined || refreshLock) {
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
        /* Create our container for the table alongside the anchor DOM that
         * is managed by mithril.
         */

        let restoredFromCache = false;

        /* This reverses the caching operation performed in onremove. If
         * the table was previously cached we replace the empty <div /> the
         * view renders with HTML from the cache. All the event handlers
         * will still be attached since we DID NOT CLONE the HTML when we
         * cached it. We then mark us as having restored from the cache
         * so that other oncreate logic knows wether to run or not.
         */
        if (isCacheEnabled) {
            const $maybeCachedTable = $(`#data-table-cache-${id}`).children();
            if ($maybeCachedTable.length > 0) {
                $anchor.after($maybeCachedTable);
                restoredFromCache = true;
            }
        }

        if (!restoredFromCache) {
            $anchor.after(`
                <div id="${id}">
                    <table id="__table__${id}" class="display table compact" style="width:100%"></table>
                </div>
            `);
            const datatable = $(`#__table__${id}`).DataTable({
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

        refreshLock = false;
        maybeRefreshData(config.data);

        if (!restoredFromCache && setup) {
            setup(id, getDataTable(), config);
        }
    }

    function onremove({ dom : ref }) {
        if (!isCacheEnabled) {
            setData(null);
            setDataTable(null);
            /* clear out our unmanaged DOM */
            $(ref).siblings().remove();
        }

        /* To cache the table we create a <div /> to contain the table HTML
         * inside if it doesn't already exist. Since we may have already
         * stored a cached value inside the <div /> but not used it we
         * delete all the children of the <div />. We then move the DOM tree
         * into that div.
         */
        if ($(`#data-table-cache-${id}`).length === 0) {
            $("#data-table-cache").append(
                `<div id="data-table-cache-${id}"></div>`
            );
        }
        const $cachedTable = $(`#data-table-cache-${id}`).first();
        $cachedTable.empty()

        /* We can't use the dom attribute of the vnode because for some reason
         * when we replace it in oncreate (when restoring from cache) it
         * doesn't know...
         */
        const $currentTable = $(`#${id}`);
        $cachedTable.append($currentTable);
    }

    return { oninit, view, oncreate, onremove };
}