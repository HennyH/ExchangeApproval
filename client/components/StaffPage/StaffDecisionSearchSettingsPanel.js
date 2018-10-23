import m from 'mithril';
import classNames from 'classnames';
import { Form } from 'powerform'

import { CheckboxGroup, Select2, OptionsField } from 'FormHelpers'
import Styles from './StaffDecisionSearchSettingsPanel.css';

export class StaffUnitSearchSettingsPowerForm extends Form {
    constructor({
        studentOptions,
        studentOfficeOptions,
        applicationStateOptions,
        dateOptions,
        ...config
    }) {
        super(config)
        this.studentNumbers = OptionsField.new({
            multiple: true,
            options: studentOptions
        });
        this.studentOffices = OptionsField.new({
            multiple: true,
            options: studentOfficeOptions
        });
        this.applicationStatuses = OptionsField.new({
            multiple: true,
            options: applicationStateOptions
        });
        Form.new.call(() => this, config);
        this.config = config;
    }
}


export default function StaffDecisionSearchSettingsPanel() {

    const state = {};

    function oninit({ attrs }) {
        state.form = new StaffUnitSearchSettingsPowerForm(attrs);
    }

    function handleSubmit(event, onSubmit) {
        event.preventDefault();
        event.stopPropagation();
        onSubmit(state.form.getData());
    }

    function view({
        attrs: {
            studentOptions,
            studentOfficeOptions,
            applicationStateOptions,
            onSubmit
        }
    }) {
        return (
            <form onsubmit={e => handleSubmit(e, onSubmit)}>
                <div class="row">
                    <div class="col-lg-4 col-md-12 form-group">
                        <label for="students">Students</label>
                        <Select2
                            field={state.form.studentNumbers}
                            config={{
                                multiple: true,
                                width: '100%',
                                placeholder: 'Select students to filter to...',
                                data: studentOptions.map(({ label, value }) => ({
                                    id: value,
                                    text: label
                                }))
                            }}
                        />
                    </div>
                    <div class="col-lg-5 col-md-12 form-group">
                        <label>Student Office</label>
                        <Select2
                            field={state.form.studentOffices}
                            config={{
                                multiple: true,
                                width: '100%',
                                placeholder: 'Select unit coordinators to filter to...',
                                data: studentOfficeOptions.map(({ label, value }) => ({
                                    id: value,
                                    text: label
                                }))
                            }}
                        />
                    </div>
                    <div class="col-sm-1 form-group">
                        <label>Application Status</label>
                        <CheckboxGroup
                            field={state.form.applicationStatuses}
                            options={applicationStateOptions}
                        />
                    </div>
                    <div class="col-auto form-group align-self-end">
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