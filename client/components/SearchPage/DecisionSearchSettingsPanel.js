import m from 'mithril';
import classNames from 'classnames';
import { Form } from 'powerform'

import { CheckboxGroup, Select2, OptionsField } from 'FormHelpers'


export class DecisionSearchSettingsPowerForm extends Form {
    constructor({
        exchangeUniversityNameOptions,
        uwaUnitLevelOptions,
        ...config
    }) {
        super(config)
        this.exchangeUniversities = OptionsField.new({
            multiple: true,
            options: exchangeUniversityNameOptions
        });
        this.unitLevels = OptionsField.new({
            multiple: true,
            options: uwaUnitLevelOptions
        })
        Form.new.call(() => this, config);
        this.config = config;
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
                    <div class="col-6 from-group">
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
                    <div class="col-auto form-group pt-md-2">
                        <label>Unit Level(s)</label>
                        <CheckboxGroup
                            field={form.unitLevels}
                            options={form.unitLevels.config.options}
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

    return { view };
}
