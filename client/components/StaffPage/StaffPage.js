import m from 'mithril'

import Layout from 'Components/Layout'
import StaffDecisionSearchSettingsPanelContainer from './StaffDecisionSearchSettingsPanelContainer.js'
import { COLUMN_NAMES, default as InboxTable } from './InboxTable.js';
import { ApplicationPowerForm } from '../ApplicationPage/ApplicationForm';
import ApplicationModal from './ApplicationModal.js';

const MOCK_DECISIONS = [
    {
        "id": 7,
        "studentName": "Augustin Gan",
        "studentNumber": "21313131",
        "decisionDate": "1995-04-08T00:00:00",
        "exchangeUniversityName": "University of New York",
        "exchangeUniversityHref": "https://university.com",
        "approved": true
    },
    {
        "id": 18,
        "studentName": "Henry Hollingworth",
        "studentNumber": "21313221",
        "decisionDate": null,
        "exchangeUniversityName": "University of Los Angeles",
        "exchangeUniversityHref": "https://university.com",
        "approved": null
    },
    {
        "id": 23,
        "studentName": "Jason Cheng",
        "studentNumber": "21345675",
        "decisionDate": "2010-03-16T00:00:00",
        "exchangeUniversityName": "University of Fort Worth",
        "exchangeUniversityHref": "https://university.com",
        "approved": false
    }
]

// const applicationPowerForm = new ApplicationPowerForm({
//     onChange: showData,
//     unitLevelOptions: [{"label":"Zero","value":0,"selected":true},{"label":"One","value":1,"selected":true},{"label":"Two","value":2,"selected":true},{"label":"Three","value":3,"selected":true},{"label":"Four","value":4,"selected":true},{"label":"GtFour","value":5,"selected":true}]
// })

// function showData() {
//     return console.log(applicationPowerForm ? JSON.stringify(applicationPowerForm.getData(), null, 4) : null);
// }

export default function StaffPage() {

    function view() {
        return (
            <Layout>
                <div class="container-fluid">
                    <div class="row">
                        <div class="col">
                            <div class="card bg-light mt-3 mb-3">
                                <div class="card-header">Search Settings</div>
                                <div class="card-body">
                                    <StaffDecisionSearchSettingsPanelContainer onsubmit={console.log} />
                                </div>
                            </div>
                            <div class="card bg-light mt-3 mb-3">
                                <div class="card-header">Search Results</div>
                                <div class="card-body">
                                    <InboxTable
                                        decisions={MOCK_DECISIONS}
                                    />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
				<ApplicationModal 
					// form={applicationPowerForm}
					// studentName = {} // Hard-coded
				/>
            </Layout>
        );
    }

    return { view };
}