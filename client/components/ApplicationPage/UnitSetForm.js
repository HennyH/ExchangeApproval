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
import {EmailData} from '../ViewData'

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
            factory: ({...config}) => new UnitPowerForm({ ...config }),
            required: true
        });
        this.uwaUnitsForm = FormListField.new({
            factory: ({...config}) => new UnitPowerForm({ ...config }),
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

function StaffApprovalContainer(form) {
	return (
		<div class="card-footer">
				<StaffUnitSetApprovalForm form={form.staffApprovalForm}/>
		</div>
	)
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
					<textarea class="form-control" field={form.comment}/>
				</div>
			</div>
		)
    }

    return { view }
}

export function UnitSetForm() {

    function view({ attrs: { formIndex, onDelete, form, class: classes, staffView, ...otherAttrs }}) {
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
                                    <button class="btn-sm ml-2 btn-outline-primary float-right" onclick={() => EmailData.Equivalence.SendEmail(formIndex)}>Email Equivalence</button>
                                    <button class="btn-sm ml-2 btn-outline-secondary float-right" onclick={() => EmailData.Equivalence.CopyText(formIndex)}>Copy to Clipboard</button>
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
                                field={form.exchangeUnitsForm}
                                addItemText="Add Exchange Unit"
                                jumps={false}
                                render={UnitForm}
                                readonly={readonly}
                            />
                        </div>
                    </div>
                    <div class="card bg-light mt-3">
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
                </div>
				{staffView ? StaffApprovalContainer(form) : null}
            </div>
        )
    }

    return { view };
}
