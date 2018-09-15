import m from 'mithril'
import classNames from 'classnames'
import { Form } from 'powerform'

import { Input, Select, OptionsField, IntegerField, StringField, FormListField }  from 'FormHelpers'
import Styles from './UnitSetForm.css'
import { FormRepeater } from '../FormHelpers/FormRepeater';
import { FormField } from '../FormHelpers/Fields';
import CheckboxGroup from '../FormHelpers/CheckboxGroup';
import RadioGroup from '../FormHelpers/RadioGroup';

export class UnitPowerForm extends Form {
    constructor({ ...config }) {
        super(config);
        this.unitName = StringField.new({ required: true });
        this.unitCode = StringField.new({ required: true });
        this.unitHref = StringField.new({
            required: true,
            regex: /^https?\:\/\//,
            regexErrorMessage: 'Enter a URL of the from https://...'
        });
        Form.new.call(() => this, config);
        this.config = config;
    }
}

export class StaffUnitSetApprovalPowerForm extends Form {
    constructor({ unitLevelOptions, ...config }) {
        super(config);
        this.equivalentUnitLevel = OptionsField.new({
            required: true,
            options: [
                { value: null, label: 'Pending' },
                ...unitLevelOptions
            ],
            default: { value: null, label: 'Pending', selected: true }
        });
        this.isContextuallyApproved = OptionsField.new({
            required: true,
            options: [
                { value: null, label: 'Pending' },
                { value: true, label: 'Approved' },
                { value: false, label: 'Denied' }
            ],
            default: { value: null, label: 'Pending', selected: true }
        });
        this.isEquivalent = OptionsField.new({
            required: true,
            options: [
                { value: null, label: 'Pending' },
                { value: true, label: 'Approved' },
                { value: false, label: 'Denied' }
            ],
            default: { value: null, label: 'Pending', selected: true }
        });
        this.comment = StringField.new();
        Form.new.call(() => this, config);
        this.config = config;
    }
}

export class UnitSetPowerForm extends Form {
    constructor({ unitLevelOptions, ...config }) {
        super(config);
        this.precedentUnitSetId = IntegerField.new();
        this.applicationId = IntegerField.new();
        this.exchangeUnitsForm = FormListField.new({
            factory: ({...config}) => new UnitPowerForm({ ...config, unitLevelOptions }),
            required: true
        });
        this.uwaUnitsForm = FormListField.new({
            factory: ({...config}) => new UnitPowerForm({ ...config, unitLevelOptions }),
            required: true
        });
        this.staffApprovalForm = new FormField({
            form: new StaffUnitSetApprovalPowerForm({ unitLevelOptions })
        })
        Form.new.call(() => this, config);
        this.config = config;
    }
}

function UnitForm() {
    function view({ attrs: { form, readonly = false }}) {
        return (
            <div class="form-row">
                <div class="col">
                    <label class="col-form-label-sm" for="exch-unit-code">Unit Name:</label>
                    <Input readonly={readonly} field={form.unitName} type="text" />
                </div>
                <div class="col">
                    <label class="col-form-label-sm"  for="exch-unit-code">Unit Code:</label>
                    <Input readonly={readonly} field={form.unitCode} type="text" />
                </div>
                <div class="col">
                    <label class="col-form-label-sm" for="exch-unit-href">Unit Outline Link:</label>
                    <Input readonly={readonly} field={form.unitHref} type="text" />
                </div>
            </div>
        )
    }

    return { view }
}

function StaffUnitSetApprovalForm() {
    function view({ attrs: { form }}) {
        return (
            <div class="form-row">
                <div class="col-3">
                    <label class="col-form-label-sm" for="exch-unit-code">Equivalent UWA Level:</label>
                    <Select field={form.equivalentUnitLevel} />
                </div>
                <div class="col-4 ml-auto">
                    <label class="col-form-label-sm ml-3" for="exch-unit-code">Contextual Approval:</label>
                    <RadioGroup field={form.isContextuallyApproved} />
                </div>
                <div class="col-4">
                    <label class="col-form-label-sm" for="exch-unit-code">Equivalence Decision:</label>
                    <RadioGroup field={form.isEquivalent} />
                </div>
            </div>
        )
    }

    return { view }
}

export function UnitSetForm() {

    function view({ attrs: { title = "Unit Set", form, readonly, class: classes, ...otherAttrs }}) {
        return (
            <div class={classNames("card", classes)} {...otherAttrs}>
                <div class="card-header">
                    {title}
                </div>
                <div class="card-body">
                    <div class="card">
                        <div class="card-header">
                            Exchange Units
                        </div>
                        <div class="card-body">
                            <FormRepeater
                                field={form.exchangeUnitsForm}
                                jumps={false}
                                form={UnitForm}
                                readonly={readonly}
                                onchange={console.log}
                            />
                        </div>
                    </div>
                    <div class="card mt-3">
                        <div class="card-header">
                            UWA Units
                        </div>
                        <div class="card-body">
                            <FormRepeater
                                field={form.uwaUnitsForm}
                                jumps={false}
                                form={UnitForm}
                                readonly={readonly}
                                onchange={console.log}
                            />
                        </div>
                    </div>
                    <div class="card mt-3">
                        <div class="card-header">
                            <em>Staff Approval</em>
                        </div>
                        <div class="card-body">
                            <StaffUnitSetApprovalForm form={form.staffApprovalForm} />
                        </div>
                    </div>
                </div>
            </div>
        )
    }

    return { view };
}
