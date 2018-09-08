import m from 'mithril'
import classNames from 'classnames';

import Layout from 'Components/Layout'

import { default as Cart } from 'Components/Cart';
import DecisionSearchContainer from 'Components/DecisionSearch/DecisionSearchContainer.js';


export default function SearchPage() {

    function view() {
        return (
            <Layout>
                <div class="container">
                    <div class="card bg-light mb-3">
                        <div class="card-header">Cart</div>
                        <div class="card-body">
                            <Cart />
                        </div>
                    </div>
                    <DecisionSearchContainer />
                </div>
            </Layout>
        );
    }

    return { view };
}