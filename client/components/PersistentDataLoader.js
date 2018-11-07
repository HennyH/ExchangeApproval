import m from 'mithril';
import DataLoader from 'Components/DataLoader.js'

window.PERSISTENT_DATA_LOADER_CACHE = window.PERSISTENT_DATA_LOADER_CACHE || {};

function getLoaderKeyFromAttrs(attrs) {
    return Object
        .getOwnPropertyNames(attrs)
        .map(n => `${n}=${attrs[n].toString()}`)
        .join(',');
}


export default function PersistentDataLoader() {

    let prevKey = null;

    function view({ attrs }) {
        return (
            <DataLoader
                {...attrs}
                render={({ loading, errored, data }) => {
                    const key = getLoaderKeyFromAttrs(attrs);
                    /* Changing the props to the data loader invalidates our
                     * cache of the data.
                     */
                    if (prevKey !== null && prevKey !== key) {
                        delete window.PERSISTENT_DATA_LOADER_CACHE[key];
                    }
                    if (!loading) {
                        window.PERSISTENT_DATA_LOADER_CACHE[key] = { loading, errored, data };
                    }
                    const restoredProps = {
                        loading,
                        errored,
                        data,
                        ...(window.PERSISTENT_DATA_LOADER_CACHE[key] || {})
                    };
                    prevKey = key;
                    return  attrs.render(restoredProps);
                }}
            />
        )
    }

    return { view };
}

