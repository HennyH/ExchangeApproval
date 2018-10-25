import m from 'mithril'
import classNames from 'classnames'
import { Form } from 'Components/FormHelpers'

import { Input, Select, OptionsField, IntegerField, StringField, FormListField, BooleanField }  from 'FormHelpers'
import Styles from './UnitSetForm.css'
import { FormRepeater } from '../FormHelpers/FormRepeater';
import { FormField } from '../FormHelpers/Fields';
import CheckboxGroup from '../FormHelpers/CheckboxGroup';
import RadioButtonGroup from '../FormHelpers/RadioButtonGroup';
import DeleteButton from '../FormHelpers/DeleteButton';
import { removeItemFromCart } from 'Components/Cart'
import {EmailData} from '../ViewData'

export class UnitPowerForm extends Form {
    configureFields() {
        this.unitName = StringField.new({ required: true });
        this.unitCode = StringField.new({ required: true });
        this.unitHref = StringField.new({
            required: true,
            regex: /^https?\:\/\//,
            regexErrorMessage: 'Enter a URL of the from https://...'
        });
    }
}

export class StaffUnitSetApprovalPowerForm extends Form {
    configureFields({ unitLevelOptions }) {
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
                { value: null, label: 'Pending', className: 'btn-outline-primary' },
                { value: true, label: 'Approved', className: 'btn-outline-success'  },
                { value: false, label: 'Denied', className: 'btn-outline-danger' }
            ],
            default: { value: null, label: 'Pending', selected: true }
        });
        this.isEquivalent = OptionsField.new({
            required: true,
            options: [
                { value: null, label: 'Pending', className: 'btn-outline-primary' },
                { value: true, label: 'Approved', className: 'btn-outline-success' },
                { value: false, label: 'Denied', className: 'btn-outline-danger' }
            ],
            default: { value: null, label: 'Pending', selected: true }
        });
        this.comments = StringField.new();
    }
}

export class UnitSetPowerForm extends Form {
    configureFields({ unitLevelOptions }) {
        this.cartItemId = IntegerField.new();
        this.unitSetId = IntegerField.new();
        this.readonly = BooleanField.new({ defualtValue: false });
        this.applicationId = IntegerField.new();
        this.exchangeUnitForms = FormListField.new({
            factory: (data) => {
                const form = new UnitPowerForm();
                form.setData(data);
                return form;
            },
            required: true
        });
        this.uwaUnitForms = FormListField.new({
            factory: (data) => {
                const form = new UnitPowerForm();
                form.setData(data);
                return form;
            },
            required: false
        });
        this.staffApprovalForm = new FormField({
            form: new StaffUnitSetApprovalPowerForm({ unitLevelOptions })
        })
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
            <div>
                <div class="form-row">
                    <div class="col-xl-4 mr-3">
                        <label class="col-form-label-sm">Equivalent UWA Level:</label>
                        <Select field={form.equivalentUnitLevel} />
                    </div>
                    <div class="row col-xl-8">
                        <div class="col-md">
                            <label class="col-form-label-sm">Contextual Approval:</label>
                            <RadioButtonGroup field={form.isContextuallyApproved} />
                        </div>
                        <div class="col-md">
                            <label class="col-form-label-sm">Equivalence Decision:</label>
                            <RadioButtonGroup field={form.isEquivalent} />
                        </div>
                    </div>
                </div>
                <div class="form-row px-1">
                    <label class="col-form-label-sm">Comments</label>
                    <textarea
                        class="form-control"
                        spellcheck={true}
                        placeholder="Enter a comment to the student..."
                        oninput={(event) => {
                            form.comments.setData(event.target.value);
                        }}
                    >
                        {form.comments.getData()}
                    </textarea>
                </div>
            </div>
        )
    }

    return { view }
}

export function UnitSetForm() {

    function view({ attrs: { formIndex, onDelete, form, className: classes, staffView, ...otherAttrs }}) {
        const title = `Unit Set ${formIndex + 1} ${form.config.cartItem && !staffView ? "(From Cart)" : ""}`;
        const readonly = (form.readonly.getData() || staffView);
        return (
            <div class={classNames("card", classes)} {...otherAttrs}>
                <div class="card-header">
                    <div class="d-flex justify-content-between">
                        <div class="align-self-center">
                            {title}
                        </div>
                        <div class="col" style="width: 3em">
                            {(staffView) ?
                                <span>
                                    <button class="btn btn-sm ml-2 btn-outline-secondary float-right" onclick={() => EmailData.Equivalence.CopyText(formIndex)}>
                                        📋 Copy to Clipboard
                                    </button>
                                    <button class="btn btn-sm ml-2 btn-outline-primary float-right" onclick={() => EmailData.Equivalence.SendEmail(formIndex)}>
                                        ✉ Email Equivalence
                                    </button>
                                </span>
                                : <span class="float-right">
                                    <DeleteButton
                                        onClick={() => {
                                            if (form.config.cartItem) {
                                                removeItemFromCart(form.config.cartItem);
                                            }
                                            onDelete();
                                        }}
                                    />
                                </span>
                            }
                        </div>
                    </div>
                </div>
                <div class="card-body">
                    <div class="card bg-light">
                        <div class="card-header">
                            Exchange Units
                        </div>
                        <div class="card-body">
                            <FormRepeater
                                field={form.exchangeUnitForms}
                                readonly={staffView}
                                jumps={false}
                                render={({ form, removeForm }) => (
                                    <UnitForm
                                        form={form}
                                        onDelete={removeForm}
                                        readonly={staffView}
                                    />
                                )}
                                footer={({ forms, addForm }) => {
                                    const numberOfForms = forms.length;
                                    return !staffView && (
                                        <div class={classNames(numberOfForms > 0 ? "mt-3" : "")}>
                                            <button
                                                type="button"
                                                class="mb-1 mr-3 btn btn-primary"
                                                onclick={() => addForm({ staffView })}
                                            >
                                                Add Exchange Unit
                                            </button>
                                        </div>
                                    );
                                }}
                            />
                        </div>
                    </div>
                    <div class="card bg-light mt-3">
                        <div class="card-header">
                            UWA Units
                        </div>
                        <div class="card-body">
                            <FormRepeater
                                field={form.uwaUnitForms}
                                readonly={staffView}
                                jumps={false}
                                render={({ form, removeForm }) => (
                                    <UnitForm
                                        form={form}
                                        onDelete={removeForm}
                                        readonly={staffView}
                                    />
                                )}
                                footer={({ forms, addForm }) => {
                                    const numberOfForms = forms.length;
                                    /* Rather than display an empty gray box
                                     * when the student entered no UWA units
                                     * (as is the case for an elective) show a
                                     * N/A to show it wasn't an error.
                                     */
                                    if (staffView && numberOfForms === 0) {
                                        return (
                                            <div class="text-center" style="width: 100%">
                                                <b>N/A</b>
                                            </div>
                                        )
                                    }
                                    return !staffView && (
                                        <div class={classNames(numberOfForms > 0 ? "mt-3" : "")}>
                                            <button
                                                type="button"
                                                class="mb-1 mr-3 btn btn-primary"
                                                onclick={() => addForm({ staffView })}
                                            >
                                                Add UWA Unit
                                            </button>
                                            {numberOfForms == 0 && (
                                                <small class="text-muted mt-1">
                                                    To nominate an Exchange Unit as an elective in your course, leave UWA units empty.
                                                </small>
                                            )}
                                        </div>
                                    );
                                }}
                            />
                        </div>
                    </div>
                </div>
                {staffView && (
                    <div class="card-footer">
                        <StaffUnitSetApprovalForm form={form.staffApprovalForm}/>
                    </div>
                )}
            </div>
        )
    }

    return { view };
}
