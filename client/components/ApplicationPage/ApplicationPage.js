import m from 'mithril'

import Layout from 'Components/Layout'
import ApplicationForm, { ApplicationPowerForm } from './ApplicationForm'
import Spinner from 'Components/Spinners/RectangularSpinner.js';
import DataLoader from 'Components/DataLoader.js'


export default function ApplicationPage() {

    const state = {
        hasSubmittedForm: false,
        applicationForm: null
    };

    function fetchFilters() {
        return m.request({
            method: "GET",
            url: window.LOGGED_IN ? "/api/filters/staff" : "/api/filters/student"
        });
    }

    function handleFormSubmitted() {
        m.request({
            method: "POST",
            url: "api/application/submit",
            data: state.applicationForm.getData()
        }).then(() => {
            state.hasSubmittedForm = true;
        });
    }

    function view() {
        return (
            <Layout>
                {state.hasSubmittedForm
                    ? (
                        <div class="card my-3">
                            <div class="card-header">Application complete!</div>
                            <div class="card-body text-center">
                                <h6>Thank you for your application. </h6>
                                <br/>Your allocated student office staff will process the application and get back to you soon!<br/><br/>
                                <em>Please check your student email regularly.</em>
                            </div>
                        </div>
                    ) : (
                        <DataLoader
                            requests={{filters: fetchFilters}}
                            render={({ loading, errored, data: { filters } = {}}) => {
                                if (loading || errored) {
                                    return <Spinner />
                                }
                                if (state.applicationForm === null) {
                                    state.applicationForm = new ApplicationPowerForm({
                                        unitLevelOptions: filters.unitLevelOptions,
                                        studentOfficeOptions: filters.studentOfficeOptions,
                                    });
                                }
                                return (
                                    <div class="container-fluid">
                                        <div class="card my-3">
                                            <div class="card-header"> Exchange Application</div>
                                            <ApplicationForm form={state.applicationForm} onSubmit={handleFormSubmitted} />
                                        </div>
                                    </div>
                                );
                            }}
                        />
                    )}
            </Layout>
        )
    }

    return { view }
}