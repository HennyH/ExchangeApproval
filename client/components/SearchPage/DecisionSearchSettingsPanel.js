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
            <form class="mb-0" onsubmit={handleSubmit.bind(this, onSearchSettingsChanged)}>
                <div class="row mb-4 mx-1">
                    <div class="input-group">
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
				</div>
				<div class="row mx-1 mb-0">
					<div class="col form-group">
                        <label>Unit Level(s)</label>
                        <CheckboxGroup
                            field={state.form.unitLevels}
                            options={levelOptions}
                        />
                    </div>
                    <div class="col-sm-6 form-group">
                        <label>Approval Type(s)</label>
                        <CheckboxGroup
                            field={state.form.approvalTypes}
                            options={contextOptions}
                        />
                    </div>
                    <div class="col-auto form-group align-self-end mb-0">
                        <button type="submit" class="btn btn-primary mb-0">
                            Search
                        </button>
                    </div>
                </div>
            </form>
        );
    }

    return { oninit, view };
}
