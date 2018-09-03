import m from 'mithril'
import classNames from 'classnames'

import { StudentDetailsForm, StudentDetailsPowerForm } from './StudentDetailsForm.js'
import { ExchangeUniversityDetailsForm, ExchangeUniversityDetailsPowerForm } from './ExchangeUniversityDetailsForm.js'
import { UnitApprovalRequestItemForm, UnitApprovalRequestItemPowerForm } from './UnitApprovalRequestItemForm.js'
import {
    CART_EVENTS,
    removeItemFromCart,
    getItemsInCart,
    addCartEventHandler,
    removeCartEventHandler
} from 'Components/Cart'

window.NEXT_APPROVAL_REQUEST_FORM_ID = 1;

export default function ApplicationForm() {

    let updateCartDerivedRequestItemsOnCartChangeCallback = null;
    const state = {
        scrollToLastRequest: false,
        studentDetailsForm: null,
        exchangeUniversityDetailsForm: null,
        approvalRequestForms: []
    };

    function oninit({ attrs: { contextTypeOptions, electiveContextTypeOption, changeCallback }}) {
        /* Create the power forms that'll be used in the view, and which the changeCallbacks
         * argument will be derived.
         */
        state.studentDetailsForm = StudentDetailsPowerForm.new({
            onChange: () => handleChange(changeCallback)
        });
        state.exchangeUniversityDetailsForm = ExchangeUniversityDetailsPowerForm.new({
            onChange: () => handleChange(changeCallback)
        });
        state.approvalRequestForms = [];

        /* When the form initalizes we need to create approval request forms
         * for all the items already in the cart. We also need to register the
         * same function to be called whenever the cart changes.
         */
        updateCartDerivedRequestItemsOnCartChangeCallback = (items) => updateCartDerivedRequestItems({
            cartItems: items,
            contextTypeOptions,
            electiveContextTypeOption,
            changeCallback
        });
        updateCartDerivedRequestItemsOnCartChangeCallback(getItemsInCart());
        addCartEventHandler(
            CART_EVENTS.CART_CHANGED,
            updateCartDerivedRequestItemsOnCartChangeCallback
        );
    }

    function onremove() {
        /* Ensure we remove the callback we attached for cart changes. */
        if (updateCartDerivedRequestItemsOnCartChangeCallback) {
            removeCartEventHandler(
                CART_EVENTS.CART_CHANGED,
                updateCartDerivedRequestItemsOnCartChangeCallback
            );
        }
    }

    function view({ attrs: { contextTypeOptions, electiveContextTypeOption, changeCallback } }) {
        const appliedAddNewRequestForm = () => {
            const nextId = window.NEXT_APPROVAL_REQUEST_FORM_ID++;
            addNewApprovalRequestForm({
                id: nextId,
                isFromCart: false,
                contextTypeOptions,
                electiveContextTypeOption,
                changeCallback,
                scrollToForm: true,
                invokeChangeCallback: true
            });
        };
        const numberRequestForms = state.approvalRequestForms.length;
        return (
            <div class="container">
                <div class="card bg-light mt-3 mb-3">
                    <div class="card-header">Student Details</div>
                    <div class="card-body">
                        <StudentDetailsForm form={state.studentDetailsForm} />
                    </div>
                </div>
                <div class="card bg-light mt-3 mb-3">
                    <div class="card-header">Exchange University Details</div>
                    <div class="card-body">
                    <ExchangeUniversityDetailsForm form={state.exchangeUniversityDetailsForm} />
                    </div>
                </div>
                <div class="card bg-light mt-3 mb-3">
                    <div class="card-header">Unit Approval Requests</div>
                    <div class="card-body">
                        {(numberRequestForms > 1
                            ? (
                                <button type="button" class="mb-1 btn btn-link" onclick={scrollToLastRequestItem}>
                                    Jump To Bottom
                                </button>
                            )
                            : <div />
                        )}
                        {state.approvalRequestForms.map(({ id, isFromCart, form }, i) => (
                            <div class={classNames("card bg-light mt-1", i == numberRequestForms - 1 ? "mb-1" : "mb-2")}>
                                <div class="card-header">Request {i + 1} {isFromCart ? "(From Cart)" : ""}</div>
                                <div class="card-body">
                                    <UnitApprovalRequestItemForm
                                        class="request-item-form"
                                        readonly={isFromCart}
                                        key={id}
                                        form={form}
                                        electiveContextTypeOption={electiveContextTypeOption}
                                        ondelete={() => removeApprovalRequestForm(id, changeCallback)}
                                    />
                                </div>
                            </div>
                        ))}
                        <button type="button" class={classNames(numberRequestForms > 0 ? "mt-3" : null, "mb-1 mr-3 btn btn-primary")} onclick={appliedAddNewRequestForm}>
                                Add Request
                        </button>
                        {(numberRequestForms > 1
                            ? (
                                <button type="button" class={classNames(numberRequestForms > 0 ? "mt-3" : null, "mb-1 mr-3 btn btn-link")} onclick={scrollToFirstRequestItem}>
                                        Jump To Top
                                </button>
                            )
                            : <div />
                        )}
                    </div>
                </div>
            </div>
        )
    }

    function onupdate() {
        if (state.scrollToLastRequest) {
            state.scrollToLastRequest = false;
            scrollToLastRequestItem();
        }
    }

    function handleChange(callback) {
        const isValid =
            state.studentDetailsForm.isValid() &&
            state.exchangeUniversityDetailsForm.isValid() &&
            !state.approvalRequestForms.some(({ form }) => !form.isValid());
        callback(
            {
                student: state.studentDetailsForm.getData(),
                exchangeUniversity: state.exchangeUniversityDetailsForm.getData(),
                approvalRequests: state.approvalRequestForms.map(({ form }) => form.getData())
            },
            isValid
        );
    }

    function scrollToLastRequestItem() {
        const $lastItemForm = $('.request-item-form').last()
        const topOffset = $lastItemForm.offset().top;
        window.scroll({
            top: topOffset,
            behavior: 'smooth'
        });
    }

    function scrollToFirstRequestItem() {
        const $lastItemForm = $('.request-item-form').first()
        const topOffset = $lastItemForm.offset().top;
        window.scroll({
            top: window.screenY - topOffset,
            behavior: 'smooth'
        });
    }

    function updateCartDerivedRequestItems({
        cartItems,
        contextTypeOptions,
        electiveContextTypeOption,
        changeCallback
    }) {
        const cartItemIds = []
        for (let cartItem of cartItems) {
            const cartItemId = btoa(JSON.stringify(cartItem));
            cartItemIds.push(cartItemId);
            /* Add a new form that is derived from the cart item if one
             * hasn't already been added for it.
             */
            if (!state.approvalRequestForms.some(({ id }) => id === cartItemId)) {
                addNewApprovalRequestForm({
                    id: cartItemId,
                    isFromCart: true,
                    contextTypeOptions,
                    electiveContextTypeOption,
                    changeCallback,
                    invokeChangeCallback: false,
                    scrollToForm: false,
                    cartItem: cartItem,
                    powerFormProps: {
                        /* This sets the default values for the form. */
                        data: {
                            exchangeUnitName: cartItem.exchange_unit_name,
                            exchangeUnitCode: cartItem.exchange_unit_code,
                            exchangeUnitOutlineHref: cartItem.exchange_unit_outline_href,
                            contextType: new Option(
                                cartItem.uwa_unit_context_name,
                                cartItem.uwa_unit_context_id,
                                false,
                                true
                            ),
                            uwaUnitName: cartItem.uwa_unit_name,
                            uwaUnitCode: cartItem.uwa_unit_code
                        }
                    }
                });
            }
        }

        /* Keep all requests that weren't derived from the cart and ones that
         * are based on items still in the cart. This captures the case where
         * something is removed from the cart and we need to drop the form
         * for it.
         */
        state.approvalRequestForms = state.approvalRequestForms.filter(f =>
            !f.isFromCart ||
            cartItems.some(i => btoa(JSON.stringify(i)) === f.id)
        );

        handleChange(changeCallback);
    }

    function addNewApprovalRequestForm({
        id,
        isFromCart = false,
        contextTypeOptions,
        electiveContextTypeOption,
        changeCallback,
        invokeChangeCallback = true,
        scrollToForm = true,
        powerFormProps = {},
        ...formProps
    }) {
        const form = new UnitApprovalRequestItemPowerForm({
            contextTypeOptions,
            electiveContextTypeOption,
            onChange: () => handleChange(changeCallback),
            ...powerFormProps
        });
        state.approvalRequestForms.push({ id, isFromCart, form, ...formProps});
        if (invokeChangeCallback) {
            handleChange(changeCallback);
        }
        if (scrollToForm) {
            /* This flag will be consumed in the onupdate lifecycle method
             * after the view re-renders (at which point the new form will
             * exist) and hence the DOM changes. We can then scroll to it.
             */
            state.scrollToLastRequest = true;
        }
        return form;
    }

    function removeApprovalRequestForm(id, changeCallback) {
        const index = state.approvalRequestForms.findIndex(f => f.id === id);
        if (index >= 0) {
            const form = state.approvalRequestForms[index];
            state.approvalRequestForms.splice(index, 1);
            if (form.isFromCart) {
                removeItemFromCart(form.cartItem);
            }
            handleChange(changeCallback);
        }
    }

    return { oninit, onremove, view, onupdate };
}