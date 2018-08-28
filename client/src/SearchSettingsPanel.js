import m from 'mithril';
import classNames from 'classnames';
import { Form } from 'powerform'

import CheckboxGroup from './FormHelpers/CheckboxGroup'
import Select2 from './FormHelpers/Select2'
import { OptionsField } from './FormHelpers/Fields'
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
        const {
            exchangeUniversities: universitiesField,
            approvalTypes: approvalTypesField,
            unitLevels: unitLevelsField
        } = state.form;
        return (
            <form onsubmit={handleSubmit.bind(this, onsubmit)}>
                <fieldset class={Styles.fieldset}>
                    <legend class={Styles.legend}>Search Settings</legend>
                    <div class="row">
                        <div class="col-6">
                            <label for="universities">Exchange Universitys</label>
                            <Select2
                                field={universitiesField}
                                config={{
                                    multiple: true,
                                    width: 'resolve',
                                    placeholder: 'Select universities to filter to...',
                                    data: exchangeUniversities
                                }}
                                onchange={x => console.log(state.form.getData())}
                            />
                        </div>
                        <div class="col">
                            <label>Approval Type(s)</label>
                            <CheckboxGroup
                                field={approvalTypesField}
                                options={contextOptions}
                                onchange={x => console.log(state.form.getData())}
                            />
                        </div>
                        <div class="col">
                            <label>Unit Level(s)</label>
                            <CheckboxGroup
                                field={unitLevelsField}
                                options={levelOptions}
                                onchange={x => console.log(state.form.getData())}
                            />
                        </div>
                        <div class="col">
                            <button type="submit" class="btn btn-primary">
                                Search
                            </button>
                        </div>
                    </div>
                </fieldset>
            </form>
        );
    }

    function oncreate(vnode) {
        const $submitButton = $(vnode.dom).find('button[type="submit"]');
        $submitButton.css('margin-top', $submitButton.parent().height() - $submitButton.height());
        $submitButton.css('margin-left', $submitButton.parent().width() - $submitButton.width());
    }

    return { view, oninit, oncreate };
}