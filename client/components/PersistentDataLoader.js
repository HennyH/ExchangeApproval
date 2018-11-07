import m from 'mithril';
import DataLoader from 'Components/DataLoader.js'
import shallowEqualObjects from 'shallow-equal/objects';

window.PERSISTENT_DATA_LOADER_CACHE = window.PERSISTENT_DATA_LOADER_CACHE || {};


export default function PersistentDataLoader() {

    let prevAttrs = null;

    function oninit({ attrs: { id } }) {
        if (!id) {
            throw new Error('Must provide an id to <PersistentDataLoader />');
        }
    }

    function view({ attrs: { id, render, requests, ...otherAttrs } }) {
        const cached = window.PERSISTENT_DATA_LOADER_CACHE[id];
        if (cached && (!prevAttrs || shallowEqualObjects(prevAttrs, otherAttrs))) {
            prevAttrs = otherAttrs;
            return render(cached);
        }
        return (
            <DataLoader
                {...otherAttrs}
                requests={requests}
                render={result => {
                    if (!result.loading) {
                        window.PERSISTENT_DATA_LOADER_CACHE[id] = result;
                        prevAttrs = otherAttrs;
                    }
                    return  render(result);
                }}
            />
        );
    }

    return { oninit, view };
}

