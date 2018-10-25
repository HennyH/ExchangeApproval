import m from 'mithril'
import classNames from 'classnames'

import { StudentDetailsForm, StudentDetailsPowerForm } from './StudentDetailsForm.js'
import { ExchangeUniversityDetailsForm, ExchangeUniversityDetailsPowerForm } from './ExchangeUniversityDetailsForm.js'
import { UnitSetForm, UnitSetPowerForm } from './UnitSetForm.js'
import {
    CART_EVENTS,
    removeItemFromCart,
    getCartItemById,
    getCardItemId,
    isItemIdInCart,
    getItemsInCart,
    addCartEventHandler,
    removeCartEventHandler
} from 'Components/Cart'
import { FormRepeater } from '../FormHelpers/FormRepeater.js';
import { Form, FormField, FormListField, IntegerField } from '../FormHelpers';
import { EmailData } from '../ViewData.js'

export class ApplicationPowerForm extends Form {
    configureFields({ unitLevelOptions = [], studentOfficeOptions = [], ...config }) {
        this.applicationId = new IntegerField({
            required: false
        });
        this.studentDetailsForm = new FormField({
            form: new StudentDetailsPowerForm({studentOfficeOptions})
        });
        this.exchangeUniversityForm = new FormField({
            form: new ExchangeUniversityDetailsPowerForm()
        });
        this.unitSetForms = FormListField.new({
            factory: (data) => {
                const form = new UnitSetPowerForm({
                    unitLevelOptions
                });
                form.setData(data);
                return form;
            },
            required: true
        });
    }
}

export default function ApplicationForm() {

    const state = { hasTriedToSubmit: false };

    function oninit(vnode) {
        EmailData.Form = vnode.attrs.staffView ? vnode.attrs.form : null;
        reRegisterCartChangeHandler(vnode);
        updateUnitSetsFromCart(vnode.attrs.form, getItemsInCart());
    }

    function view({
        attrs: { form, staffView = false, onSubmit }
    }) {
        const validationClass = state.hasTriedToSubmit
            ? (form.isValid() ? 'is-valid' : 'is-invalid')
            : '';
        const errorMessage = "This form is not valid. Please check all fields for validation errors";
        return (
            <div class="container-fluid">
                <div class="card-body">
                    <div class="card bg-light mt-3 mb-3">
                        <div class="card-header">Student Details</div>
                        <div class="card-body">
                            <StudentDetailsForm form={form.studentDetailsForm} staffView={staffView} />
                        </div>
                    </div>
                    <div class="card bg-light mt-3 mb-3">
                        <div class="card-header">Exchange University Details</div>
                        <div class="card-body">
                            <ExchangeUniversityDetailsForm form={form.exchangeUniversityForm} staffView={staffView} />
                        </div>
                    </div>
                    <div class="card bg-light mt-3 mb-3">
                        <div class="card-header">Unit Approval Requests</div>
                        <div class="card-body">
                            <FormRepeater
                                jumps={!staffView}
                                field={form.unitSetForms}
                                readonly={staffView}
                                render={({ index, form, removeForm }) => (
                                    <UnitSetForm
                                        form={form}
                                        formIndex={index}
                                        onDelete={removeForm}
                                        staffView={staffView}
                                        className="mt-3"
                                    />
                                )}
                                onRemoveForm={({ form }) => {
                                    const cartItemId = form.cartItemId.getData();
                                    if (cartItemId) {
                                        const cartItem = getCartItemById(cartItemId);
                                        removeItemFromCart(cartItem, true);
                                    }
                                }}
                                footer={({ forms, addForm }) => {
                                    const numberOfForms = forms.length;
                                    return !staffView && (
                                        <div class={classNames(numberOfForms > 0 ? "mt-3" : "")}>
                                            <button
                                                type="button"
                                                class="mb-1 mr-3 btn btn-primary"
                                                onclick={() => addForm({ staffView })}
                                            >
                                                    {"Add Unit Set"}
                                            </button>
                                            <button
                                                class="btn btn-primary"
                                                class={"mb-1 mr-3 btn btn-primary"}
                                                oncreate={m.route.link}
                                                href="/search"
                                            >
                                                    Search for Units
                                            </button>
                                        </div>
                                    );
                                }}
                            />
                        </div>
                    </div>
                    {!staffView && (
                        <div class="card bg-light mt-3 mb-3">
                            <div class="card-body">
                                <button type="button" class="btn btn-success" style="width: 100%" onclick={() => handleSubmit(form, onSubmit)}>
                                    Submit Application
                                </button>
                                <input type="hidden" class={classNames(validationClass, "form-control")} />
                                <span class="invalid-feedback mt-3 mb-2" style="width: 100%; text-align: center; font-size: 100%">
                                    {errorMessage}
                                </span>
                            </div>
                        </div>
                    )}
                </div>
            </div>
        )
    }

    function handleSubmit(form, onSubmit) {
        if (form.isValid()) {
            onSubmit();
        } else {
            state.hasTriedToSubmit = true;
            form.setDirty(true);
        }
    }


    /* cart functionality */
    function onbeforeupdate(vnode, old) {
        reRegisterCartChangeHandler(vnode);
        updateUnitSetsFromCart(vnode.attrs.form, getItemsInCart());
    }

    function reRegisterCartChangeHandler(vnode) {
        removeCartEventHandler(CART_EVENTS.CART_CHANGED, "application-form", null);
        addCartEventHandler(
            CART_EVENTS.CART_CHANGED,
            "application-form",
            items => updateUnitSetsFromCart(vnode.attrs.form, items)
        );
    }

    function updateUnitSetsFromCart(form, items) {
        const formsToDrop = form.unitSetForms.forms.reduce(
            (agg, f) => {
                const cartItemId = f.cartItemId.getData();
                if (cartItemId && !isItemIdInCart(cartItemId)) {
                    agg.push(f);
                }
                return agg;
            },
            []
        );
        let redraw = formsToDrop.length > 0;
        formsToDrop.map(f => form.unitSetForms.removeForm(f));
        items.forEach(cartItem => {
            const cartItemId = getCardItemId(cartItem);
            if (!form.unitSetForms.forms.some(f => f.cartItemId.getData() === cartItemId)) {
                form.unitSetForms.unshiftForm({
                    cartItemId,
                    exchangeUnitForms: cartItem.exchangeUnits.map(u => ({
                        unitName: u.unitName,
                        unitCode: u.unitCode,
                        unitHref: u.unitHref
                    })),
                    uwaUnitForms: cartItem.uwaUnits.map(u => ({
                        unitName: u.unitName,
                        unitCode: u.unitCode,
                        unitHref: u.unitHref
                    })),
                    readonly: true
                });
                redraw = true;
            }
        });
        if (redraw) {
            m.redraw();
        }
    }

    return { oninit, onbeforeupdate,  view }
}

