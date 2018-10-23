import m from 'mithril'
import ApplicationForm, { ApplicationPowerForm } from '../ApplicationPage/ApplicationForm.js';
import Spinner from 'Components/Spinners/RectangularSpinner.js';
import {EmailData, ApplicationSearchData} from '../ViewData'

export var DownloadModalContent = {
    view: function() {
        return (
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="ModalTitle">Faculty List</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <form>
                        <div class="form-group">
                            <label for="DownloadCSV">Download Faculty List: </label>
                            <br/>
                            <button id="DownloadCSV" type="button" class="btn btn-outline-primary">
                                {/* <span class="fas fa-cloud-download" aria-hidden="true"></span> */}
                                Download
                            </button>
                        </div>
                        <div class="form-group">
                            <br/>
                            <label for="UploadCSV">Upload Faculty List: </label>
                            <input type="file" class="form-control-file" id="UploadCSV"/>
                        </div>
                    </form >
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary" data-dismiss="modal">Save changes</button>
                </div>
            </div>
            
        );
    }
}

export var LoginModalContent = {
    view: function({attrs: {onSubmit}}) {
        return (
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="ModalTitle">Log In</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <form>
                        <div class="form-group">
                            <input class="form-control" type="password" placeholder="Password" name ="Password"/>
                        </div>
                    </form >
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary" data-dismiss="modal" onclick={onSubmit}>Login</button>
                </div>
            </div>
        );
    }
}

export var ApplicationModalContent = {
    oninit: function() {
            ApplicationSearchData.filters.fetch();
    },

    view: function({attrs: {title}}) {
        return (
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="ModalTitle">{title}</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body p-0">
                    {(ApplicationSearchData.filters.loading
                        ? <Spinner style="top: calc(50% - 32px); left: calc(50% - 32px); position: absolute;" />
                        : (
                            <ApplicationForm 
                                // WE WILL NEED TO REDIRECT THESE TO THE CORRECT FILTERS
                                unitLevelOptions = {ApplicationSearchData.filters.options.unitLevelOptions}
                                studentOfficeOptions = {ApplicationSearchData.filters.options.studentOfficeOptions}
                                staffView ={true} 
                                // config = {Fetched application data}
                            />
                        )
                    )}    
                </div>
                <div class="modal-footer d-flex justify-content-between">
                    <div class="">
                        <button type="button" class="btn btn-outline-primary mx-1" onclick={() => EmailData.Student.SendEmail(applicationPowerForm.getData())}>Send Application Results</button>
                        <button type="button" class="btn btn-outline-secondary mx-1" onclick={() => EmailData.Student.CopyText(applicationPowerForm.getData())}>Copy to Clipboard</button>
                    </div>
                    <div class="">
                        <button type="button" class="btn btn-secondary mx-1" data-dismiss="modal">Cancel</button>
                        <button type="button" class="btn btn-primary mx-1" data-dismiss="modal">Save Application</button>
                    </div>
                </div>
            </div>
        );
    }
}
