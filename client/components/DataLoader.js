import m from 'mithril';

export default function DataLoader() {

    const state = {
        loading: true,
        errored: undefined,
        data: {}
    };

    function oninit({ attrs: { requests }}) {
        fetchData(requests);
    }

    function fetchData(requests) {
        state.loading = true;
        state.errored = false;
        state.data = {};

        const $deferred = $.Deferred();
        const data = {};
        const fetches = [];
        const mrs = Object.keys(requests).map(prop => {
            const $fetch = $.Deferred();
            fetches.push($fetch);
            const $mr = requests[prop]().then((json) => {
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

    function view({ attrs: { render } }) {
        return render({...state});
    }

    return { view, oninit };
}