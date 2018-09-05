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


window.APPLICATION_FORM = window.APPLICATION_FORM || {
    NEXT_APPROVAL_REQUEST_FORM_ID: 1,
    APPROVAL_REQUEST_ITEM_FORMS: [],
    STUDENT_DETAILS_FORM: StudentDetailsPowerForm.new({
        onChange: emitApplicationFormChangedEvent
    }),
    EXCHANGE_UNIVERSITY_DETAILS_FORM: ExchangeUniversityDetailsPowerForm.new({
        onChange: emitApplicationFormChangedEvent
    }),
    CHANGE_CALLBACK: () => {}
}

function emitApplicationFormChangedEvent() {
    const isValid =
        window.APPLICATION_FORM.STUDENT_DETAILS_FORM.isValid() &&
        window.APPLICATION_FORM.EXCHANGE_UNIVERSITY_DETAILS_FORM.isValid() &&
        !window.APPLICATION_FORM.APPROVAL_REQUEST_ITEM_FORMS.some(({ form }) => !form.isValid());
    window.APPLICATION_FORM.CHANGE_CALLBACK(
        {
            student: window.APPLICATION_FORM.STUDENT_DETAILS_FORM.getData(),
            exchangeUniversity: window.APPLICATION_FORM.EXCHANGE_UNIVERSITY_DETAILS_FORM.getData(),
            approvalRequests: window.APPLICATION_FORM.APPROVAL_REQUEST_ITEM_FORMS.map(({ form }) => form.getData())
        },
        isValid
    );
}

export default function ApplicationForm() {

    let updateCartDerivedRequestItemsOnCartChangeCallback = null;
    const state = { scrollToLastRequest: false };

    function oninit({ attrs: { contextTypeOptions, electiveContextTypeOption, changeCallback }}) {
        window.APPLICATION_FORM.CHANGE_CALLBACK = changeCallback;
        /* When the form initalizes we need to create approval request forms
         * for all the items already in the cart. We also need to register the
         * same function to be called whenever the cart changes.
         */
        updateCartDerivedRequestItemsOnCartChangeCallback = (items) => updateCartDerivedRequestItems({
            cartItems: items,
            contextTypeOptions,
            electiveContextTypeOption
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
        /* Update the callback function which gets triggered when the form changes */
        window.APPLICATION_FORM.CHANGE_CALLBACK = changeCallback;
        const appliedAddNewRequestForm = () => {
            const nextId = window.APPLICATION_FORM.NEXT_APPROVAL_REQUEST_FORM_ID++;
            addNewApprovalRequestForm({
                id: nextId,
                isFromCart: false,
                contextTypeOptions,
                electiveContextTypeOption,
                scrollToForm: true,
                invokeChangeCallback: true
            });
        };
        const numberRequestForms = window.APPLICATION_FORM.APPROVAL_REQUEST_ITEM_FORMS.length;
        return (
            <div class="container">
                <div class="card bg-light mt-3 mb-3">
                    <div class="card-header">Student Details</div>
                    <div class="card-body">
                        <StudentDetailsForm form={window.APPLICATION_FORM.STUDENT_DETAILS_FORM} />
                    </div>
                </div>
                <div class="card bg-light mt-3 mb-3">
                    <div class="card-header">Exchange University Details</div>
                    <div class="card-body">
                    <ExchangeUniversityDetailsForm form={window.APPLICATION_FORM.EXCHANGE_UNIVERSITY_DETAILS_FORM} />
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
                        {window.APPLICATION_FORM.APPROVAL_REQUEST_ITEM_FORMS.map(({ id, isFromCart, form }, i) => (
                            <div class={classNames("card bg-light mt-1", i == numberRequestForms - 1 ? "mb-1" : "mb-2")}>
                                <div class="card-header">Request {i + 1} {isFromCart ? "(From Cart)" : ""}</div>
                                <div class="card-body">
                                    <UnitApprovalRequestItemForm
                                        class="request-item-form"
                                        readonly={isFromCart}
                                        key={id}
                                        form={form}
                                        electiveContextTypeOption={electiveContextTypeOption}
                                        ondelete={() => removeApprovalRequestForm(id)}
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
    }) {
        const cartItemIds = []
        for (let cartItem of cartItems) {
            const cartItemId = btoa(JSON.stringify(cartItem));
            cartItemIds.push(cartItemId);
            /* Add a new form that is derived from the cart item if one
             * hasn't already been added for it.
             */
            if (!window.APPLICATION_FORM.APPROVAL_REQUEST_ITEM_FORMS.some(({ id }) => id === cartItemId)) {
                addNewApprovalRequestForm({
                    id: cartItemId,
                    isFromCart: true,
                    contextTypeOptions,
                    electiveContextTypeOption,
                    invokeChangeCallback: false,
                    scrollToForm: false,
                    cartItem: cartItem,
                    powerFormProps: {
                        /* This sets the default values for the form. */
                        data: {
                            id: cartItem.id,
                            exchangeUnitName: cartItem.exchangeUnitName,
                            exchangeUnitCode: cartItem.exchangeUnitCode,
                            exchangeUnitOutlineHref: cartItem.exchangeUnitOutlineHref,
                            contextType: new Option(
                                cartItem.uwaUnitContext,
                                cartItem.uwaUnitContext,
                                false,
                                true
                            ),
                            uwaUnitName: cartItem.uwaUnitName,
                            uwaUnitCode: cartItem.uwaUnitCode
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
        window.APPLICATION_FORM.APPROVAL_REQUEST_ITEM_FORMS = window.APPLICATION_FORM.APPROVAL_REQUEST_ITEM_FORMS.filter(f =>
            !f.isFromCart ||
            cartItems.some(i => btoa(JSON.stringify(i)) === f.id)
        );

        emitApplicationFormChangedEvent();
    }

    function addNewApprovalRequestForm({
        id,
        isFromCart = false,
        contextTypeOptions,
        electiveContextTypeOption,
        invokeChangeCallback = true,
        scrollToForm = true,
        powerFormProps = {},
        ...formProps
    }) {
        const form = new UnitApprovalRequestItemPowerForm({
            contextTypeOptions,
            electiveContextTypeOption,
            onChange: () => emitApplicationFormChangedEvent,
            ...powerFormProps
        });

        /* If it's from the cart insert it at the top of the list */
        if (isFromCart) {
            window.APPLICATION_FORM.APPROVAL_REQUEST_ITEM_FORMS.unshift({ id, isFromCart, form, ...formProps});
        } else {
            window.APPLICATION_FORM.APPROVAL_REQUEST_ITEM_FORMS.push({ id, isFromCart, form, ...formProps});
        }

        if (invokeChangeCallback) {
            emitApplicationFormChangedEvent();
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

    function removeApprovalRequestForm(id) {
        const index = window.APPLICATION_FORM.APPROVAL_REQUEST_ITEM_FORMS.findIndex(f => f.id === id);
        if (index >= 0) {
            const form = window.APPLICATION_FORM.APPROVAL_REQUEST_ITEM_FORMS[index];
            window.APPLICATION_FORM.APPROVAL_REQUEST_ITEM_FORMS.splice(index, 1);
            if (form.isFromCart) {
                removeItemFromCart(form.cartItem);
            }
            emitApplicationFormChangedEvent();
        }
    }

    return { oninit, onremove, view, onupdate };
}