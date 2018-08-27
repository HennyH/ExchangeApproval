import m from 'mithril'

import SearchSettingsPanel from './SearchSettingsPanel'

const Data = {
    filters: {
        options: null,
        fetch: () => {
            m.request({
                method: "GET",
                url: "https://localhost:5001/api/values/filters"
            }).then(options => {
                Data.filters.options = options;
            });
        }
    }
}

export default function SearchSettingsPanelContainer() {
    function oninit() {
        Data.filters.fetch();
    }

    function view({ attrs }) {
        if (!Data.filters.options) {
            return <div />;
        }

        return (
            <SearchSettingsPanel
                {...attrs}
                exchangeUniversities={Data.filters.options.exchangeUniversities.map(({ id, name }) => ({ id, text: name }))}
                levelOptions={Data.filters.options.levelOptions.map(({ id, name }) => ({ value: id, label: name}))}
                contextOptions={Data.filters.options.contextOptions.map(({ id, name }) => ({ value: id, label: name}))}
            />
        );
    }

    return { oninit, view };
}