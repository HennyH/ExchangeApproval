import m from 'mithril';
import classNames from 'classnames';
import { Form } from 'powerform'

import { CheckboxGroup, Select2, OptionsField } from 'FormHelpers'


class DecisionSearchSettingsPowerForm extends Form {
    exchangeUniversities = OptionsField.new({ multiple: true });
    approvalTypes = OptionsField.new({ multiple: true });
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
                                data: exchangeUniversityOptions.map(({ label, value }) => ({
                                    id: value,
                                    text: label
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

    return { oninit, view };
}
