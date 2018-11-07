import m from 'mithril'

import DataTable from 'Components/DataTable'
import {
    COLUMN_NAMES as DECISION_TABLE_COLUMN_NAMES,
    makeDecisionsTableConfig,
    default as DecisionsTable
} from 'Components/SearchPage/DecisionsTable.js'
import {CartData as CART} from '../ViewData.js'

export const CART_EVENTS = {
    CART_CHANGED: 'CART_CHANGED'
};

window.NEXT_ITEM_ID = 1;

export function makeCartTableConfig(cartItems) {
    const decisionsTableConfig = makeDecisionsTableConfig(cartItems);
    const columnsToKeep = [
        DECISION_TABLE_COLUMN_NAMES.Type,
        DECISION_TABLE_COLUMN_NAMES.ExchangeUniversity,
        DECISION_TABLE_COLUMN_NAMES.ExchangeUnit,
        DECISION_TABLE_COLUMN_NAMES.UWAUnit
    ];
    return {
        ...decisionsTableConfig,
        columns: [
            ...decisionsTableConfig.columns.filter(c => columnsToKeep.includes(c.title)),
            {
                title: 'Remove',
                data: null,
                defaultContent: "<button type='button' class='btn btn-outline-secondary'>🗑️</button>"
            }
        ],
        paging: false,
        searching: false,
        info: false
    }
}

export function getItemsInCart() {
    return [...CART.items];
}

export function emitCartEvent(name, ...args) {
    if (name === CART_EVENTS.CART_CHANGED) {
        args = [CART.items, ...args]
    }

    for (let handler of CART.handlers) {
        if (handler.name === name) {
            handler.func(...args);
        }
    }

    m.redraw();
}

export function addItemToCart(item, emitEvent = true) {
    /* Avoid adding duplicates to a cart by removing any previous copies
     * of the item.
     */
    removeItemFromCart(item, false);
    item.__CART_ITEM_ID = window.NEXT_ITEM_ID++;
    CART.items = [item, ...CART.items];
    if (emitEvent) {
        emitCartEvent(CART_EVENTS.CART_CHANGED);
    }
}

export function removeItemFromCart(item, emitEvent = true) {
    CART.items = CART.items.filter(i => i !== item);
    if (emitEvent) {
        emitCartEvent(CART_EVENTS.CART_CHANGED);
    }
}

export function isItemInCart(item) {
    return CART.items.indexOf(item) >= 0
        || (item && item.__CART_ITEM_ID !== undefined
                && CART.items.some(i => i.__CART_ITEM_ID === item.__CART_ITEM_ID));
}

export function isItemIdInCart(itemId) {
    return CART.items.some(i => i.__CART_ITEM_ID === itemId);
}

export function getCardItemId(item) {
    if (isItemInCart(item)) {
        return item.__CART_ITEM_ID;
    }
    return undefined;
}

export function getCartItemById(id) {
    return CART.items.find(i => i.__CART_ITEM_ID == id);
}

export function addCartEventHandler(name, id, callback) {
    CART.handlers.push({
        name,
        id,
        func: callback
    });
}

export function removeCartEventHandler(name, id, callback) {
    const index = CART.handlers.find(
        h => h.name === name && (h.callback === callback || h.id === id)
    );
    if (index >= 0) {
        CART.handlers.splice(index, 1);
    }
}

export default function Cart() {

    function view() {
        return !window.LOGGED_IN && (
            <div class="card bg-light my-3">
                <div class="card-header d-flex align-items-center">Cart</div>
                <div class="card-body">
                    {CART.items.length === 0 ? <h6>Cart is empty.</h6> : ''}
                    <DataTable
                        id="cart"
                        config={makeCartTableConfig(CART.items)}
                        setup={($ref, datatable) => {
                            $ref.on('click', 'button', function(event) {
                                const item = datatable.row($(event.target).parents('tr')).data();
                                removeItemFromCart(item);
                            });
                            $ref.tooltip({
                                selector: '[rel="popover"]',
                                trigger: 'hover'
                            });
                        }}
                    />
                </div>
                <div class="card-footer">
                    <button class="btn btn-primary float-right ml-auto" oncreate={m.route.link} href="/application" disabled={CART.items.length === 0}>
                            <span class="ml-2">Go to Application
                                <span class="badge badge-secondary mx-2">{CART.items.length}</span>
                            </span>
                    </button>
                </div>
            </div>
        );
    }

    return { view };
}