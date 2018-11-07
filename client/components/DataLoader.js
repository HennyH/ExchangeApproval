import m from 'mithril';
import shallowEqualObjects from 'shallow-equal/objects';

export default function DataLoader() {

    let prevArgs = null;

    const state = {
        loading: true,
        errored: undefined,
        data: {},
        $fetching: null
    };

    function oninit({ attrs: { requests, render, ...arg }}) {
        fetchData(requests, arg);
    }

    function fetchData(requests, arg) {
        if (state.$fetching) {
            state.$fetching.reject();
        }

        const $fetching = $.Deferred();

        state.loading = true;
        state.errored = false;
        state.data = {};
        state.$fetching = $fetching;

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
                return $fetching;
            });
            return $mr;
        });

        const $allMrs = Promise.all(fetches);
        /* If any of the m.requests failed we should reject the overall process
         * and display an error state.
         */
        $allMrs.catch((err) => {
            state.loading = false;
            state.errored = err;
            state.data = {};
            $fetching.reject();
        });
        /* If all the m.requests succeed consider the overall fetching as
         * a success.
         */
        $allMrs.then(() => {
            $fetching.resolve();
        });

        /* If something else cancels our fetching work, we should cancel all
         * the m.fetch promises we created.
         */
        $fetching.catch(() => {
            mrs.forEach($mr => $mr.reject());
        });
        /* If our fetching works then set a success state. */
        $fetching.then(() => {
            state.loading = false;
            state.errored = undefined;
            state.data = data;
        })
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