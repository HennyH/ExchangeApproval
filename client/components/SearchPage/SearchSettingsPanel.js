import m from 'mithril';
import classNames from 'classnames';
import { Form } from 'powerform'

import { CheckboxGroup, Select2, OptionsField } from 'FormHelpers'
import Styles from './SearchSettingsPanel.css';

class SearchSettingsPowerForm extends Form {
    exchangeUniversities = OptionsField.new({ multiple: true });
    approvalTypes = OptionsField.new({ multiple: true });
    unitLevels = OptionsField.new({ multiple: true })
}


export default function SearchSettingsPanel() {

    const state = {};

    function oninit() {
        state.form = SearchSettingsPowerForm.new();
    }

    function handleSubmit(callback, event) {
        event.preventDefault();
        event.stopPropagation();
        callback(state.form.getData());
    }

    function view({
        attrs: {
            onsubmit,
            levelOptions,
            contextOptions,
            exchangeUniversities
        }
    }) {
        return (
            <form onsubmit={handleSubmit.bind(this, onsubmit)}>
                <div class="row">
                    <div class="col-lg-6 col-md-12 form-group">
                        <label for="universities">Exchange Universitys</label>
                        <Select2
                            field={state.form.exchangeUniversities}
                            config={{
                                multiple: true,
                                width: '100%',
                                placeholder: 'Select universities to filter to...',
                                data: exchangeUniversities.map(name => ({
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