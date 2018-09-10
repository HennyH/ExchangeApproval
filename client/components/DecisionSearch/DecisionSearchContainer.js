import m from 'mithril';
import classNames from 'classnames';
import { Form } from 'powerform'

import { CheckboxGroup, Select2, OptionsField } from 'FormHelpers'
import { addItemToCart } from 'Components/Cart';
import Spinner from 'Components/Spinners/RectangularSpinner';
import DecisionsTable from './DecisionsTable.js';

class DecisionSearchSettingsPowerForm extends Form {
    exchangeUniversities = OptionsField.new({ multiple: true });
    approvalTypes = OptionsField.new({ multiple: true });
    unitLevels = OptionsField.new({ multiple: true })
}


export function DecisionSearchSettingsPanel() {

    const state = {};

    function oninit() {
        state.form = DecisionSearchSettingsPowerForm.new();
    }

    function handleSubmit(callback, event) {
        event.preventDefault();
        event.stopPropagation();
        callback(state.form.getData());
    }

    function view({
        attrs: {
            onSearchSettingsChanged,
            levelOptions,
            contextOptions,
            exchangeUniversityOptions
        }
    }) {
        return (
            <form onsubmit={handleSubmit.bind(this, onSearchSettingsChanged)}>
                <div class="row">
                    <div class="col-lg-6 col-md-12 form-group">
                        <label for="universities">Exchange Universities</label>
                        <Select2
                            field={state.form.exchangeUniversities}
                            config={{
                                multiple: true,
                                width: '100%',
                                placeholder: 'Select universities to filter to...',
                                data: exchangeUniversityOptions.map(name => ({
                                    id: name,
                                    text: name
                                }))
                            }}
                        />
                    </div>
                    <div class="col-lg-auto col-md-12 from-group">
                        <label>Approval Type(s)</label>
                        <CheckboxGroup
                            field={state.form.approvalTypes}
                            options={contextOptions}
                        />
                    </div>
                    <div class="col-lg-auto col-md-12 form-group">
                        <label>Unit Level(s)</label>
                        <CheckboxGroup
                            field={state.form.unitLevels}
                            options={levelOptions}
                        />
                    </div>
                    <div class="col-lg-auto col-md-12 form-group align-self-end">
                        <button type="submit" class="btn btn-primary">
                            Search
                        </button>
                    </div>
                </div>
            </form>
        );
    }

    return { view, oninit };
}

export function DecisionSearch() {
    function view({
        attrs: {
            class: classes,
            isLoading = false,
            decisions,
            onAddToCart,
            onSearchSettingsChanged,
            exchangeUniversityOptions,
            levelOptions,
            contextOptions,
            ...otherAttrs
        }
    }) {
        return (
            <div class={classNames("card bg-light", classes)} {...otherAttrs}>
                <div class="card-header">Decision Search</div>
                <div class="card-body">
                    <div class="card bg-light mt-1 mb-2">
                        <div class="card-header">Search Settings</div>
                        <div class="card-body">
                            <DecisionSearchSettingsPanel
                                onSearchSettingsChanged={onSearchSettingsChanged}
                                exchangeUniversityOptions={exchangeUniversityOptions}
                                levelOptions={levelOptions}
                                contextOptions={contextOptions}
                            />
                        </div>
                    </div>
                    <div class="card bg-light mt-1">
                        <div class="card-header">Search Results</div>
                        <div class={classNames("card-body", isLoading ? "text-center": "")}>
                            {(isLoading
                                ? <Spinner />
                                : <DecisionsTable decisions={decisions}
                                onAddToCart={onAddToCart}
                                />
                            )}
                        </div>
                    </div>
                </div>
            </div>
        )
    }

    return { view }
}

const Data = {
    filters: {
        options: null,
        fetch: () => {
            m.request({
                method: "GET",
                url: "/api/requests/filters"
            }).then(options => {
                Data.filters.options = options;
            });
        }
    },
    decisions: {
        loading: false,
        list: [],
        fetch: ({ universityNames = [], uwaContextTypes = [], uwaUnitLevels = [] } = {}) => {
            Data.decisions.loading = true;
            const qs = m.buildQueryString({
                universityNames,
                uwaContextTypes,
                uwaUnitLevels
            });
            m.request({
                method: "GET",
                url: `/api/requests/decisions?${qs}`
            }).then(items => {
                Data.decisions.list = items;
                Data.decisions.loading = false;
            });
        }
    }
}

export default function DecisionSearchContainer() {

    function oninit() {
        Data.filters.fetch();
        Data.decisions.fetch();
    }

    function view({ attrs }) {
        if (!Data.filters.options) {
            return <div />;
        }

        return (
            <DecisionSearch
                {...attrs}
                isLoading={Data.decisions.loading}
                decisions={Data.decisions.list}
                onAddToCart={addItemToCart}
                onSearchSettingsChanged={handleSearchSettingsChanged}
                exchangeUniversityOptions={Data.filters.options.exchangeUniversityNames}
                levelOptions={Data.filters.options.uwaUnitLevelOptions}
                contextOptions={Data.filters.options.uwaUnitContextOptions}
            />
        );
    }

    function handleSearchSettingsChanged(settings) {
        const universityNames = settings.exchangeUniversities.map(({ value }) => value);
        const uwaContextTypes = settings.approvalTypes.map(({ value }) => value);
        const uwaUnitLevels = settings.unitLevels.map(({ value }) => value);
        Data.decisions.fetch({ universityNames, uwaContextTypes, uwaUnitLevels });
        m.redraw();
    }

    return { oninit, view };
}