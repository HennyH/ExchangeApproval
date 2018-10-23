import m from 'mithril'
import classNames from 'classnames'
import { Form } from 'powerform'

import { StudentDetailsForm, StudentDetailsPowerForm } from './StudentDetailsForm.js'
import { ExchangeUniversityDetailsForm, ExchangeUniversityDetailsPowerForm } from './ExchangeUniversityDetailsForm.js'
import { UnitSetForm, UnitPowerForm, UnitSetPowerForm } from './UnitSetForm.js'
import {
    CART_EVENTS,
    removeItemFromCart,
    getItemsInCart,
    addCartEventHandler,
    removeCartEventHandler
} from 'Components/Cart'
import { FormRepeater } from '../FormHelpers/FormRepeater.js';
import { FormField, FormListField } from '../FormHelpers/Fields.js';
import {ApplicationData, EmailData} from '../ViewData.js'

export class ApplicationPowerForm extends Form {
    constructor({ unitLevelOptions = [], studentOfficeOptions = [], staffView, ...config }) {
        super(config);
        this.studentDetailsForm = new FormField({
            form: new StudentDetailsPowerForm({studentOfficeOptions})
        });
        this.exchangeUniversityForm = new FormField({
            form: new ExchangeUniversityDetailsPowerForm()
        });
        this.unitSetForms = FormListField.new({
            factory: ({ ...config } = {}) => {
                const form = new UnitSetPowerForm({
                    ...config,
                    unitLevelOptions,
                    staffView
                });
                return form;
            },
            required: true
        });
        Form.new.call(() => this, config);
        this.config = config;
    }
}

export default function ApplicationForm() {

    const state = {
        hasTriedToSubmit: false,
        form: null
    };

    function oninit(vnode) {
        state.form = new ApplicationPowerForm({
            staffView: vnode.attrs.staffView,
            onChange: showData,
            unitLevelOptions: vnode.attrs.unitLevelOptions,
            studentOfficeOptions: vnode.attrs.studentOfficeOptions
        });
        EmailData.Form = (vnode.attrs.staffView ? state.form : null);
        reRegisterCartChangeHandler(vnode);
        console.log(state.form)
        updateUnitSetsFromCart(state.form, getItemsInCart());
    }

    function view({ 
        attrs: { 
            unitLevelOptions,
            studentOfficeOptions,
            staffView
        } 
    }) {
        const validationClass = state.hasTriedToSubmit
            ? (form.isValid() ? 'is-valid' : 'is-invalid')
            : '';
        const error = "This form is not valid. Please check all fields for validation errors";
        const success = "Form submitted successfully!"

        return (
            <div class="container-fluid">
                    <div class="card-body">
                        <div class="card bg-light mt-3 mb-3">
                            <div class="card-header">Student Details</div>
                            <div class="card-body">
                                <StudentDetailsForm form={state.form.studentDetailsForm} staffView={staffView} />
                            </div>
                        </div>
                        <div class="card bg-light mt-3 mb-3">
                            <div class="card-header">Exchange University Details</div>
                            <div class="card-body">
                                <ExchangeUniversityDetailsForm form={state.form.exchangeUniversityForm} staffView={staffView} />
                            </div>
                        </div>
                        <div class="card bg-light mt-3 mb-3">
                            <div class="card-header">Unit Approval Requests</div>
                            <div class="card-body">
                                <FormRepeater
                                    field={state.form.unitSetForms}
                                    render={UnitSetForm}
                                    addItemText="Add Unit Set"
                                    class="mt-3"
                                    staffView = {staffView}
                                    secondButton = {unitSearchButton()}
                                />
                            </div>
                        </div>
                        {submitButton(staffView, validationClass, error, success, state.form)}
                    </div>
            </div>
        )
    }

    function unitSearchButton() {
        return(
            <button
                class="btn btn-primary"
                class={"mb-1 mr-3 btn btn-primary"}
                oncreate={m.route.link}
                href="/search"
            >
                    Search for Units
            </button>
        )
    }

    function submitButton(staffView, validationClass, error, success, form) {
        if (!staffView) {
            return (
                <div class="card bg-light mt-3 mb-3">
                    <div class="card-body">
                        <button type="button" class="btn btn-success" style="width: 100%" onclick={() => handleSubmit(form, success)}>
                            Submit Application
                        </button>
                        <input type="hidden" class={classNames("form-control", validationClass)} />
                        <span class="invalid-feedback mt-3 mb-2" style="width: 100%; text-align: center; font-size: 100%">
                            {error}
                        </span>
                    </div>
                </div>
            )
        }
    }

    function handleSubmit(form, success) {
        state.hasTriedToSubmit = true;
        if (form.isValid()) {
            // TODO: Push to application db
            alert(success);
            ApplicationData.hasSubmitted = true;
            console.log("APPLICATION SUBMITTED", JSON.stringify(form.getData(), null, 4));
        } else {
            console.log("ERRORS", form.getError());
        }
    }

    function showData() {
        return console.log(state.form ? JSON.stringify(state.form.getData(), null, 4) : null);
    }

    /* cart functionality */
    function onbeforeupdate(vnode, old) {
        reRegisterCartChangeHandler(vnode);
        updateUnitSetsFromCart(state.form, getItemsInCart());
    }

    function reRegisterCartChangeHandler(vnode) {
        removeCartEventHandler(CART_EVENTS.CART_CHANGED, "application-form", null);
        addCartEventHandler(
            CART_EVENTS.CART_CHANGED,
            "application-form",
            items => updateUnitSetsFromCart(state.form, items)
        );
    }

    function updateUnitSetsFromCart(form, items) {
        const formsToDrop = form.unitSetForms.forms.reduce(
            (agg, f) => {
                const precedentUnitSetId = f.precedentUnitSetId.getData();
                if (precedentUnitSetId && !items.some(i => i.unitSetId === precedentUnitSetId)) {
                    agg.push(f);
                }
                return agg;
            },
            []
        );
        let redraw = formsToDrop.length > 0;
        formsToDrop.map(f => form.unitSetForms.removeForm(f));
        items.map(i => {
            if (!form.unitSetForms.forms.some(f => f.precedentUnitSetId.getData() === i.unitSetId)) {
                form.unitSetForms.unshiftForm({
                    data: {
                        precedentUnitSetId: i.unitSetId,
                        exchangeUnitsForm: i.exchangeUnits.map(u => ({
                            unitName: u.unitName,
                            unitCode: u.unitCode,
                            unitHref: u.unitHref
                        })),
                        uwaUnitsForm: i.uwaUnits.map(u => ({
                            unitName: u.unitName,
                            unitCode: u.unitCode,
                            unitHref: u.unitHref
                        }))
                    },
                    cartItem: i
                });
                redraw = true;
            }
        });
        if (redraw) {
            m.redraw();
        }
    }

    return { oninit, onbeforeupdate, view }
}

