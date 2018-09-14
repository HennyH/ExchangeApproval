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


export class ApplicationPowerForm extends Form {
    constructor({ unitLevelOptions, ...config }) {
        super(config);
        this.studentDetailsForm = new FormField({
            form: new StudentDetailsPowerForm()
        });
        this.exchangeUniversityForm = new FormField({
            form: new ExchangeUniversityDetailsPowerForm()
        });
        this.unitSetForms = FormListField.new({
            factory: ({ ...config } = {}) => {
                const form = new UnitSetPowerForm({
                    ...config,
                    unitLevelOptions
                });
                form.id = config.id || null;
                form.readonly = form.precedentUnitSetId.getData() !== null;
                return form;
            },
            required: true
        });
        Form.new.call(() => this, config);
        this.config = config;
    }
}


export default function ApplicationForm() {

    function oninit(vnode) {
        reRegisterCartChangeHandler(vnode)
        updateUnitSetsFromCart(vnode.attrs.form, getItemsInCart());
    }

    function onbeforeupdate(vnode, old) {
        reRegisterCartChangeHandler(vnode);
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
                const precedentUnitSetId = f.precedentUnitSetId.getData();
                if (precedentUnitSetId && !items.some(i => i.unitSetId === precedentUnitSetId)) {
                    agg.push(f);
                }
            },
            []
        );
        let redraw = formsToDrop.length > 0;
        formsToDrop.map(form.unitSetForms.removeForm);
        items.map(i => {
            if (!form.unitSetForms.forms.some(f => f.precedentUnitSetId.getData() === i.unitSetId)) {
                form.unitSetForms.pushForm({
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
                    }
                });
                redraw = true;
            }
        });
        if (redraw) {
            m.redraw();
        }
    }

    function view({ attrs: { form } }) {
        return (
            <div class="container">
                <div class="card mt-3">
                    <div class="card-header">
                        Exchange Application
                    </div>
                    <div class="card-body">
                        <div class="card bg-light mt-3 mb-3">
                            <div class="card-header">Student Details</div>
                            <div class="card-body">
                                <StudentDetailsForm form={form.studentDetailsForm} />
                            </div>
                        </div>
                        <div class="card bg-light mt-3 mb-3">
                            <div class="card-header">Exchange University Details</div>
                            <div class="card-body">
                                <ExchangeUniversityDetailsForm form={form.exchangeUniversityForm} />
                            </div>
                        </div>
                        <div class="card bg-light mt-3 mb-3">
                            <div class="card-header">Unit Approval Requests</div>
                            <div class="card-body">
                                <FormRepeater
                                    field={form.unitSetForms}
                                    form={UnitSetForm}
                                    class="mt-3"
                                />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        )
    }

    return { oninit, onbeforeupdate, view }
}

