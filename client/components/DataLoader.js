import m from 'mithril';
import shallowEqualObjects from 'shallow-equal/objects';

export default function DataLoader() {

    let prevArgs = null;

    const state = {
        loading: true,
        errored: undefined,
        data: {}
    };

    function oninit({ attrs: { requests, render, ...arg }}) {
        fetchData(requests, arg);
    }

    function fetchData(requests, arg) {
        state.loading = true;
        state.errored = false;
        state.data = {};

        const $deferred = $.Deferred();
        const data = {};
        const fetches = [];
        const mrs = Object.keys(requests).map(prop => {
            const $fetch = $.Deferred();
            fetches.push($fetch);
            const $mr = requests[prop](arg).then((json) => {
                data[prop] = json;
                $fetch.resolve();
                return json;
            }).then(() => {
                return $deferred;
            });
            return $mr;
        });
        return Promise.all(fetches).then(() => {
            state.loading = false;
            state.errored = undefined;
            state.data = data;
            $deferred.resolve();
        }, (err) => {
            state.loading = false;
            state.errored = err;
            state.data = {};
        });
    }

    function view({ attrs: { requests, render, ...arg } }) {
        if (prevArgs !== null && !shallowEqualObjects(prevArgs, arg)) {
            fetchData(requests, arg);
        }
        const els = render({...state, refresh: () => fetchData(requests, arg)});
        prevArgs = arg;
        return els;
    }

    return { view, oninit };
}