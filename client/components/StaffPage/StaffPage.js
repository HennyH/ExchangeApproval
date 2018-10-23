import m from 'mithril'
import classNames from 'classnames';

import Layout from 'Components/Layout'
import StaffDecisionSearchSettingsPanelContainer from './StaffDecisionSearchSettingsPanelContainer.js'
import { COLUMN_NAMES, default as InboxTable } from './InboxTable.js';
import Modal from '../Modal/Modal.js';
import {DownloadModalContent, ApplicationModalContent} from '../Modal/ModalContents.js'
import {ModalState} from '../ViewData'
import DataLoader from 'Components/DataLoader.js'
import Spinner from 'Components/Spinners/RectangularSpinner.js';

export default function StaffPage() {

    function view() {
        return (
            <Layout staff = {true} >
                <div class="container-fluid">
                    <div class="row">
                        <div class="col">
                            {/* <div class="card bg-light mt-3 mb-3">
                                <div class="card-header">Inbox Search Settings</div>
                                <div class="card-body">
                                    <StaffDecisionSearchSettingsPanelContainer onsubmit={console.log} />
                                </div>
                            </div> */}
                            <div class="card bg-light mt-3 mb-3">
                                <div class="card-header">Inbox</div>
                                <DataLoader
                                    requests={{inbox: () => m.request("/api/inbox")}}
                                    render={({ loading, error, data: { inbox } = {}}) => (
                                        loading
                                            ? <Spinner />
                                            : <InboxTable data={inbox} />
                                    )}
                                />
                            </div>
                        </div>
                    </div>
                </div>
                {ModalState.ApplicationModal.selectedApplication ? <ApplicationModal/> : <div/>}
                {ModalState.DownloadModal.visible ? <DownloadModal/> : <div/>}
            </Layout>
        );
    }

    return { view };
}

var ApplicationModal = {
    view: function() {
        return(
            <Modal size = {"xl"}>
                <ApplicationModalContent title = {"Edit Application: " + ModalState.ApplicationModal.selectedApplication.studentName}/>
            </Modal>
        );
    }
}

var DownloadModal = {
    view: function() {
        return(
            <Modal size = {"sm"}>
                    <DownloadModalContent/>
            </Modal>
        );
    }
}