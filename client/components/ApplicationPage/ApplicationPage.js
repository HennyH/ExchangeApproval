import m from 'mithril'

import Layout from 'Components/Layout'
import ApplicationForm, { ApplicationPowerForm } from './ApplicationForm'
import Spinner from 'Components/Spinners/RectangularSpinner.js';
import {ApplicationData, UnitSearchData as Data} from '../ViewData'

const applicationPowerForm = new ApplicationPowerForm({
	staffView: false,
    onChange: showData,
})

function showData() {
    return console.log(applicationPowerForm ? JSON.stringify(applicationPowerForm.getData(), null, 4) : null);
}

export default function ApplicationPage() {

    function oninit() {
        Data.filters.fetch();
    }

    function view() {
        return (
        <Layout>
            {ApplicationData.hasSubmitted ? 
            <div class="card my-3">
                <div class="card-header">Application complete!</div>
                <div class="card-body text-center">
                    <h6>Thank you for your application. </h6> 
                    <br/>Your allocated student office staff will process the application and get back to you soon!<br/><br/>
                    <em>Please check your student email regularly.</em>
                </div>
            </div>
            : (Data.filters.loading ? <Spinner style="top: calc(50% - 32px); left: calc(50% - 32px); position: absolute;" />
            : <div class="container-fluid">
                <div class="card my-3">
                    <div class="card-header"> Exchange Application</div>
                    <ApplicationForm form={applicationPowerForm} staffView ={false} />
                </div>
            </div>
            )}
        </Layout>
        )
    }


    return { oninit, view }
}