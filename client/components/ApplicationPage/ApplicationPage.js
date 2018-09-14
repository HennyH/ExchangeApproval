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
    unitLevelOptions: [{"label":"Zero","value":0,"selected":true},{"label":"One","value":1,"selected":true},{"label":"Two","value":2,"selected":true},{"label":"Three","value":3,"selected":true},{"label":"Four","value":4,"selected":true},{"label":"GtFour","value":5,"selected":true}]
})

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
                            <ApplicationForm form={applicationPowerForm} />
                        </div>
                    )
                )}
            </Layout>
        )
    }

    return { oninit, view }
}