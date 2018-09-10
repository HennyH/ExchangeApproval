import m from 'mithril'

import Layout from 'Components/Layout'
import ApplicationForm from './ApplicationForm'
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

export default function ApplicationPage() {

    function oninit() {
        Data.filters.fetch();
    }

    function view() {
        return (
            <Layout>
                {(Data.filters.loading
                    ? <Spinner style="top: calc(50% - 32px); left: calc(50% - 32px); position: absolute;" />
                    : (
                        <div class="container">
                            <ApplicationForm
                                contextTypeOptions={Data.filters.options.uwaUnitContextOptions.map(n => ({ value: n, label: n}))}
                                electiveContextTypeOption={{ value: 'Elective' }}
                                changeCallback={console.log}
                            />
                        </div>
                    )
                )}
            </Layout>
        )
    }

    return { oninit, view }
}