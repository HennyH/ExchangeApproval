import m from 'mithril'

import Layout from 'Components/Layout'
import ApplicationForm, { ApplicationPowerForm } from './ApplicationForm'
import Spinner from 'Components/Spinners/RectangularSpinner.js';
import {ApplicationSearchData, ApplicationData} from '../ViewData'


export default function ApplicationPage() {

    function oninit() {
        ApplicationSearchData.filters.fetch();
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
            : (ApplicationSearchData.filters.loading
                ? <Spinner style="top: calc(50% - 32px); left: calc(50% - 32px); position: absolute;" />
                : <div class="container-fluid">
                    <div class="card my-3">
                        <div class="card-header"> Exchange Application</div>
                        <ApplicationForm 
                            // WE WILL NEED TO REDIRECT THESE TO THE CORRECT FILTERS
                            unitLevelOptions = {ApplicationSearchData.filters.options.unitLevelOptions}
                            studentOfficeOptions = {ApplicationSearchData.filters.options.studentOfficeOptions}
                            staffView ={false} 
                        />
                    </div>
                </div>
            )}
        </Layout>
        )
    }


    return { oninit, view }
}