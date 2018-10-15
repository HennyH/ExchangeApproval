import m from 'mithril'

import Layout from 'Components/Layout'
import ApplicationForm, { ApplicationPowerForm } from './ApplicationForm'
import { UnitSetForm, UnitSetPowerForm } from './UnitSetForm.js';
import Spinner from 'Components/Spinners/RectangularSpinner.js';

const Data = {
    filters: {
        loading: false,
        options: null,
        fetch: () => {
            Data.filters.loading = true;
            m.request({
                method: "GET",
                url: "/api/requests/filters"
            }).then(options => {
                Data.filters.options = options;
                Data.filters.loading = false;
            });
        }
    }
}

const applicationPowerForm = new ApplicationPowerForm({
	staffView: false,
    onChange: showData,
    unitLevelOptions: [{"label":"Zero","value":0,"selected":true},{"label":"One","value":1,"selected":true},{"label":"Two","value":2,"selected":true},{"label":"Three","value":3,"selected":true},{"label":"Four","value":4,"selected":true},{"label":"GtFour","value":5,"selected":true}]
})

function showData() {
    return console.log(applicationPowerForm ? JSON.stringify(applicationPowerForm.getData(), null, 4) : null);
}

export default function ApplicationPage() {

    function oninit() {
        if (Data.filters.options === null) {
            Data.filters.fetch();
        }
    }

    function view() {
        return (
            <Layout>
                {(Data.filters.loading
                    ? <Spinner style="top: calc(50% - 32px); left: calc(50% - 32px); position: absolute;" />
                    : (
                        <div class="container">
							<div class="card mt-3">
                    			<div class="card-header">
                        			Exchange Application
                    			</div>
                            	<ApplicationForm form={applicationPowerForm} staffView ={false} />
							</div>
                        </div>
                    )
                )}
            </Layout>
        )
    }

    return { oninit, view }
}