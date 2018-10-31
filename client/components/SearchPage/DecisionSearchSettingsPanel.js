import m from 'mithril';
import classNames from 'classnames';
import { Form } from 'Components/FormHelpers'

import { CheckboxGroup, Select2, OptionsField } from 'FormHelpers'


export class DecisionSearchSettingsPowerForm extends Form {
    configureFields({ exchangeUniversityNameOptions, uwaUnitLevelOptions }) {
        this.exchangeUniversities = OptionsField.new({
            multiple: true,
            options: exchangeUniversityNameOptions
        });
        this.unitLevels = OptionsField.new({
            multiple: true,
            options: uwaUnitLevelOptions
        })
    }
}


export default function DecisionSearchSettingsPanel() {

    function handleSubmit(event, form, callback) {
        event.preventDefault();
        event.stopPropagation();
        callback(form.getData());
    }

    function view({ attrs: { onSearchSettingsChanged, form } }) {
        return (
            <form class="mb-0" onsubmit={(e) => handleSubmit(e, form, onSearchSettingsChanged)}>
                <div class="row">
                    <div class="col-lg-6 col-sm-12 from-group">
                        <label for="universities">Exchange Universities</label>
                        <Select2
                            field={form.exchangeUniversities}
                            config={{
                                multiple: true,
                                width: '100%',
                                placeholder: 'Select universities to filter to...',
                                data: form.exchangeUniversities.config.options.map(({ label, value }) => ({
                                    id: value,
                                    text: label
                                }))
                            }}
                        />
                    </div>
                    <div class="col-lg-6 col-sm-12 form-group pt-md-0 pt-sm-3 pt-3">
                        <label>Unit Level(s)</label>
                        <Select2
                            field={form.unitLevels}
                            config={{
                                multiple: true,
                                width: '100%',
                                placeholder: 'Select unit levels to filter to...',
                                data: form.unitLevels.config.options.map(({ label, value }) => ({
                                    id: value,
                                    text: label
                                }))
                            }}
                        />
                        {/* <CheckboxGroup
                            field={form.unitLevels}
                            options={form.unitLevels.config.options}
                        /> */}
                    </div>
                    <div class="col-lg-12 col-md-12 col-sm-12">
                        <button type="submit" class="btn btn-primary ml-3 mr-2" style="display: block; float: right;">
                            Search
                        </button>
                    </div>
                </div>
            </form>
        );
    }

    return { view };
}
