import m from 'mithril';
import classNames from 'classnames';
import { Form } from 'powerform'

import { CheckboxGroup, Select2, OptionsField } from 'FormHelpers'


class DecisionSearchSettingsPowerForm extends Form {
    exchangeUniversities = OptionsField.new({ multiple: true });
    unitLevels = OptionsField.new({ multiple: true })
}


export default function DecisionSearchSettingsPanel() {

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
            exchangeUniversityOptions
        }
    }) {
        return (
            <form class="mb-0" onsubmit={handleSubmit.bind(this, onSearchSettingsChanged)}>
                <div class="row">
                    <div class="col-auto from-group">
                        <label for="universities">Exchange Universities</label>
                        <Select2
                            field={state.form.exchangeUniversities}
                            config={{
                                multiple: true,
                                width: '100%',
                                placeholder: 'Select universities to filter to...',
                                data: exchangeUniversityOptions.map(({ label, value }) => ({
                                    id: value,
                                    text: label
                                }))
                            }}
                        />
                    </div>
                    <div class="col-auto form-group pt-md-2">
                        <label>Unit Level(s)</label>
                        <CheckboxGroup
                            field={state.form.unitLevels}
                            options={levelOptions}
                        />
                    </div>
                </div>
                <div class="row">
                    <button type="submit" class="btn btn-primary ml-3 mr-2" style="width: 100%">
                        Search
                    </button>
                </div>
            </form>
        );
    }

    return { oninit, view };
}
