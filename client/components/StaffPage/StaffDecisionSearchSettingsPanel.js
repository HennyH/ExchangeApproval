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
        this.students = OptionsField.new({
            multiple: true,
            options: studentOptions
        });
        this.studentOffices = OptionsField.new({
            multiple: true,
            options: studentOfficeOptions
        });
        this.applicationStates = OptionsField.new({
            multiple: true,
            options: applicationStateOptions
        });
        this.date = OptionsField.new({
            options: dateOptions
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

    function handleSubmit(callback, event) {
        event.preventDefault();
        event.stopPropagation();
        callback(state.form.getData());
    }

    function view({
        attrs: {
            studentOptions,
            studentOfficeOptions,
            applicationStateOptions,
            dateOptions
        }
    }) {
        return (
            <form onsubmit={handleSubmit.bind(this, onsubmit)}>
                <div class="row">
                    <div class="col-lg-6 col-md-12 form-group">
                        <label for="students">Students</label>
                        <Select2
                            field={state.form.students}
                            config={{
                                multiple: true,
                                width: '100%',
                                placeholder: 'Select students to filter to...',
                                data: studentOptions.map(name => ({
                                    id: name,
                                    text: name
                                }))
                            }}
                        />
                    </div>
                    <div class="col-lg-6 col-md-12 form-group">
                        <label>Student Office</label>
                        <Select2
                            field={state.form.studentOffices}
                            config={{
                                multiple: true,
                                width: '100%',
                                placeholder: 'Select student office to filter to...',
                                data: studentOfficeOptions.map(name => ({
                                    id: name,
                                    text: name
                                }))
                            }}
                        />
                    </div>
                </div>
                <div class="row mx-1">
                    <div class="col-sm-6 form-group">
                        <label>Application Status</label>
                        <CheckboxGroup
                            field={state.form.applicationStates}
                            options={applicationStateOptions}
                        />
                    </div>
                    <div class="col form-group">
                        <label>Filters</label>
                        <CheckboxGroup field={state.form.date} options={dateOptions} />
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