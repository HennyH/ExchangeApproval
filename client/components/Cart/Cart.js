import m from 'mithril'

import DataTable from 'Components/DataTable'
import {
    COLUMN_NAMES as DECISION_TABLE_COLUMN_NAMES,
    makeDecisionsTableConfig,
    default as DecisionsTable
} from 'Components/SearchPage/DecisionsTable.js'

window.CART = window.CART || {
    handlers: [],
    items: [
        {"unitSetId":548,"lastUpdatedAt":"2018-09-20T00:00:00","approved":true,"exchangeUniversityName":"University Of Rochester","exchangeUniversityHref":"https://university.com","exchangeUnits":[{"universityName":"University Of Rochester","universityHref":"https://university.com","unitCode":"CHE 116","unitName":"Numerical Methods And Stat","unitHref":"https://unit.com"}],"uwaUnits":[{"universityName":"University of Western Australia","universityHref":"https://uwa.edu.au","unitCode":"L2 ELECTIVE","unitName":"Knowledge Story Art","unitHref":"https://uwa.edu.au"}],"equivalentUnitLevel":{"label":"Two","value":2,"selected":true}},
        {"unitSetId":549,"lastUpdatedAt":"2018-09-20T00:00:00","approved":true,"exchangeUniversityName":"University Of Rochester","exchangeUniversityHref":"https://university.com","exchangeUnits":[{"universityName":"University Of Rochester","universityHref":"https://university.com","unitCode":"CHE 116","unitName":"Numerical Methods And Stat","unitHref":"https://unit.com"}],"uwaUnits":[{"universityName":"University of Western Australia","universityHref":"https://uwa.edu.au","unitCode":"L2 ELECTIVE","unitName":"Knowledge Story Art","unitHref":"https://uwa.edu.au"}],"equivalentUnitLevel":{"label":"Two","value":2,"selected":true}}
    ]
}

export const CART_EVENTS = {
    CART_CHANGED: 'CART_CHANGED'
};

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
    return [...window.CART.items];
}

export function emitCartEvent(name, ...args) {
    if (name === CART_EVENTS.CART_CHANGED) {
        args = [window.CART.items, ...args]
    }

    for (let handler of window.CART.handlers) {
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
    window.CART.items = [item, ...window.CART.items];
    if (emitEvent) {
        emitCartEvent(CART_EVENTS.CART_CHANGED);
    }
}

export function removeItemFromCart(item, emitEvent = true) {
    window.CART.items = window.CART.items.filter(i => i !== item);
    if (emitEvent) {
        emitCartEvent(CART_EVENTS.CART_CHANGED);
    }
}

export function isItemInCart(item) {
    return window.CART.items.indexOf(item) >= 0;
}

export function addCartEventHandler(name, id, callback) {
    window.CART.handlers.push({
        name,
        id,
        func: callback
    });
}

export function removeCartEventHandler(name, id, callback) {
    const index = window.CART.handlers.find(
        h => h.name === name && (h.callback === callback || h.id === id)
    );
    if (index >= 0) {
        window.CART.handlers.splice(index, 1);
    }
}

export default function Cart() {

    function view() {
        return (
			<div class="card bg-light my-3">
				<div class="card-header d-flex align-items-center">Cart</div>
				<div class="card-body">
					{window.CART.items.length === 0 ? <h6>Cart is empty.</h6> : ''}
					<DataTable
						config={makeCartTableConfig(window.CART.items)}
						setup={(id, datatable) => {
							$(`#${id} tbody`).on('click', 'button', function(event) {
								const item = datatable.row($(event.target).parents('tr')).data();
								removeItemFromCart(item);
							});
							$(`#${id} tbody`).tooltip({
								selector: '[rel="popover"]',
								trigger: 'hover'
							});
						}}
					/>
				</div>
				<div class="card-footer">
					<button class="btn btn-primary float-right ml-auto" oncreate={m.route.link} href="/application" disabled={window.CART.items.length === 0}>
							<span class="ml-2">Back to Application
								<span class="badge badge-secondary mx-2">{window.CART.items.length}</span>
							</span>
					</button>
				</div>
			</div>
        );
    }

    return { view };
}