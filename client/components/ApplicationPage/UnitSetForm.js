import m from 'mithril'
import classNames from 'classnames'
import { Form } from 'powerform'

import { Input, Select, OptionsField, IntegerField, StringField, FormListField, BooleanField }  from 'FormHelpers'
import Styles from './UnitSetForm.css'
import { FormRepeater } from '../FormHelpers/FormRepeater';
import { FormField } from '../FormHelpers/Fields';
import CheckboxGroup from '../FormHelpers/CheckboxGroup';
import RadioButtonGroup from '../FormHelpers/RadioButtonGroup';
import DeleteButton from '../FormHelpers/DeleteButton';
import { removeItemFromCart } from 'Components/Cart'

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
                { value: null, label: 'Pending', class: 'btn-outline-primary' },
                { value: true, label: 'Approved', class: 'btn-outline-success'  },
                { value: false, label: 'Denied', class: 'btn-outline-danger' }
            ],
            default: { value: null, label: 'Pending', selected: true }
        });
        this.isEquivalent = OptionsField.new({
            required: true,
            options: [
                { value: null, label: 'Pending', class: 'btn-outline-primary' },
                { value: true, label: 'Approved', class: 'btn-outline-success' },
                { value: false, label: 'Denied', class: 'btn-outline-danger' }
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
        this.readonly = BooleanField.new({ default: false });
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
        if (this.precedentUnitSetId.getData() !== null
            && this.precedentUnitSetId.getData() !== undefined
        ) {
            this.readonly.setData(true);
        }
    }
}

function UnitForm() {
    function view({ attrs: { form, onDelete, readonly = false }}) {
        return (
            <div class="form-row">
                {readonly
                    ? <div />
                    : (
                        <div class="col-auto" style="width: 3em">
                            <label class="col-form-label-sm">&nbsp;</label>
                            <DeleteButton onClick={onDelete} />
                        </div>
                    )

                }
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
                    <RadioButtonGroup field={form.isContextuallyApproved} />
                </div>
                <div class="col-4">
                    <label class="col-form-label-sm" for="exch-unit-code">Equivalence Decision:</label>
                    <RadioButtonGroup field={form.isEquivalent} />
                </div>
            </div>
        )
    }

    return { view }
}

export function UnitSetForm() {

    function view({ attrs: { formIndex, onDelete, form, class: classes, ...otherAttrs }}) {
        const title = `Unit Set ${formIndex + 1} ${form.config.cartItem ? "(From Cart)" : ""}`;
        const readonly = form.readonly.getData();
        return (
            <div class={classNames("card", "bg-light", classes)} {...otherAttrs}>
                <div class="card-header">
                    <div class="row">
                        <div class="col-11">
                            {title}
                        </div>
                        <div class="col-auto align-self-end" style="width: 3em">
                            <DeleteButton
                                onClick={() => {
                                    if (form.config.cartItem) {
                                        removeItemFromCart(form.config.cartItem);
                                    }
                                    onDelete();
                                }}
                            />
                        </div>
                    </div>
                </div>
                <div class="card-body">
                    <div class="card">
                        <div class="card-header">
                            Exchange Units
                        </div>
                        <div class="card-body">
                            <FormRepeater
                                field={form.exchangeUnitsForm}
                                addItemText="Add Exchange Unit"
                                jumps={false}
                                render={UnitForm}
                                readonly={readonly}
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
                                addItemText="Add UWA Unit"
                                jumps={false}
                                render={UnitForm}
                                readonly={readonly}
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
