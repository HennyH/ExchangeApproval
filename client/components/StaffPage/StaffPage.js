import m from 'mithril'

import Layout from 'Components/Layout'
import StaffDecisionSearchSettingsPanelContainer from './StaffDecisionSearchSettingsPanelContainer.js'
import { COLUMN_NAMES, default as InboxTable } from './InboxTable.js';
import Modal, { showModal }from '../Modal/Modal.js';
import ApplicationForm, { ApplicationPowerForm } from '../ApplicationPage/ApplicationForm.js';
import Spinner from 'Components/Spinners/RectangularSpinner.js';
import classNames from 'classnames'
import { loadavg } from 'os';

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

const ModalState = {
	selectedApplication: null,
	onclose: () => {ModalState.selectedApplication = null},
	// student: null,
	// exchangeUniversity: null,
	// unitsets: null,
	// // fetch: () => 
}

const applicationPowerForm = new ApplicationPowerForm({
	staffView: true,
    onChange: showData,
    unitLevelOptions: [{"label":"Zero","value":0,"selected":true},{"label":"One","value":1,"selected":true},{"label":"Two","value":2,"selected":true},{"label":"Three","value":3,"selected":true},{"label":"Four","value":4,"selected":true},{"label":"GtFour","value":5,"selected":true}]
})

function showData() {
    return console.log(applicationPowerForm ? JSON.stringify(applicationPowerForm.getData(), null, 4) : null);
}

export default function StaffPage() {

	function oninit() {
        if (Data.filters.options === null) {
			Data.filters.fetch();
		}
	}

	function onupdate() {
		showModal();
	}

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
										modalDetails={ModalState}
                                    />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
				{(ModalState.selectedApplication 
					? <Modal 
						title = {"Edit Application: " + ModalState.selectedApplication.studentName}
						modalData = {ModalState}
						size = {"xl"}
						>
						{(Data.filters.loading
							? <Spinner style="top: calc(50% - 32px); left: calc(50% - 32px); position: absolute;" />
							: (
								<ApplicationForm 
									form={applicationPowerForm} 
									staffView = {true} 
								/>
							)
						)}	
					</Modal>
					: <div/>)}
            </Layout>
        );
    }

    return { oninit, onupdate, view };
}