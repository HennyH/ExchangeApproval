import m from 'mithril'

import Layout from 'Components/Layout'
import StaffDecisionSearchSettingsPanelContainer from './StaffDecisionSearchSettingsPanelContainer.js'

export default function StaffPage() {
    function view() {
        return (
            <Layout>
                <div class="container-fluid">
                    <div class="card bg-light mt-3 mb-3">
                        <div class="card-header">Search Settings</div>
                        <div class="card-body">
                            <StaffDecisionSearchSettingsPanelContainer onsubmit={console.log} />
                        </div>
                    </div>
                    {/* <div class="card bg-light mb-3">
                        <div class="card-header">Search Resuts</div>
                        <div class="card-body">
                            <Cart />
                        </div>
                    </div>
                    <div class={classNames("card bg-light mb-3", Data.decisions.loading ? "text-center": "")}>
                        <div class="card-header">Search Results</div>
                        <div class="card-body">
                            {(Data.decisions.loading
                                ? (<Spinner />)
                                : (
                                    <DecisionsTable
                                        decisions={Data.decisions.list}
                                        onAddToCart={addItemToCart}
                                    />
                                )
                            )}
                        </div>
                    </div> */}
                </div>
            </Layout>
        );
    }

    return { view };
}