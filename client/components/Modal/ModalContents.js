import m from 'mithril'
import ApplicationForm, { ApplicationPowerForm } from '../ApplicationPage/ApplicationForm.js';
import Spinner from 'Components/Spinners/RectangularSpinner.js';
import {EmailData, ApplicationSearchData} from '../ViewData'

export function DownloadModalContent() {

    const state = {
        errors: [],
        message: null
    }

    function uploadNewEquivalencies(event) {
        const file = event.target.files[0];
        var data = new FormData();
        data.append("equivalencies", file);
        m.request({
            method: "POST",
            url: "/api/admin/equivalencies",
            data
        })
        .then(() => {
            state.message = "Upload Successful.";
            state.errors = [];
        })
        .catch(e => {
            state.message = null;
            state.errors = JSON.parse(e.message);
            m.redraw();
        });
    }

    function uploadNewDB(event) {
        const file = event.target.files[0];
        var data = new FormData();
        data.append("applications", file);
        m.request({
            method: "POST",
            url: "/api/admin/applications",
            data
        })
        .then(() => {
            state.message = "Upload Successful.";
            state.errors = [];
        })
        .catch(e => {
            state.message = null;
            state.errors = JSON.parse(e.message);
            m.redraw();
        });
    }

    function view() {
        return (
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="ModalTitle">Upload / Download</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <h6 class="text-muted">Edit Unit Equivalencies</h6>
                    <div class="form-group">
                        <a href="/api/admin/equivalencies" class="btn btn-outline-primary form-control-file" target="_blank" download="equivalencies.csv">
                            {"⇩ Download Equivalencies"}
                        </a>
                    </div>
                    <div class="form-group">
                        <label class="btn btn-outline-danger form-control-file">
                            {"⇧ Upload Equivalencies"}
                            <input name="equivalencies" type="file" onchange={uploadNewEquivalencies} hidden />
                        </label>
                    </div>
                    {state.message ? <h6>{state.message}</h6> : <span />}
                    {state.errors
                        ? (
                            <ol>
                                {state.errors.map(e => <li key={e}>{e}</li>)}
                            </ol>
                        )
                        : <span />
                    }
                    <hr/>
                    <h6 class="text-muted">Backup Database</h6>
                    <div class="form-group">
                        <a href="/api/admin/applications" class="btn btn-outline-primary form-control-file" target="_blank" download="ExchangeApprovalsDB.json">
                            {"⇩ Download Applications"}
                        </a>
                    </div>
                    <div class="form-group">
                        <label class="btn btn-outline-danger form-control-file">
                            {"⇧ Upload Applications"}
                            <input name="applications" type="file" onchange={uploadNewDB} hidden />
                        </label>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    {/* <button type="button" class="btn btn-primary" data-dismiss="modal">Save changes</button> */}
                </div>
            </div>
        );
    }

    return { view };
}

export var LoginModalContent = {
    view: function ({ attrs: { onSubmit } }) {
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

