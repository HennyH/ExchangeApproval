import m from 'mithril';
import classNames from 'classnames'
import Modal from '../Modal/Modal.js';

export default function AdminToolsModal() {

    const state = {
        equivalenciesMessage: null,
        equivalenciesErrors: [],
        applicationsMessage: null,
        applicationsErrors: []
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
            state.equivalenciesMessage = "Upload Successful.";
            state.equivalenciesErrors = [];
        })
        .catch(e => {
            state.equivalenciesMessage = null;
            state.equivalenciesErrors = JSON.parse(e.message);
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
            state.applicationsMessage = "Upload Successful.";
            state.applicationsErrors = [];
        })
        .catch(e => {
            state.applicationsMessage = null;
            state.applicationsErrors = JSON.parse(e.message);
            m.redraw();
        });
    }

    function view({ attrs }) {
        return (
            <Modal
                title="Admin Tools"
                footer={(
                    <button type="button" class="btn btn-secondary" data-dismiss="modal" style="display: block; margin-left: auto; margin-right: 0;">
                        Close
                    </button>
                )}
                {...attrs}
            >
                <div>
                    <h6 class="text-muted">Edit Historical Unit Equivalencies</h6>
                    <p>
                        This tool allows you to edit unit equivalencies that are <i>not</i> related
                        to a student application by downloading and uploading a CSV. This is useful when you have historical
                        equivalency data you wish to import into the system.
                        <br />
                        <span class="text-danger">
                        Warning: Uploading the file will <b>remove all previously uploaded historical equivalencies</b> from
                        the database, and insert new data for each equivalency in the CSV file.</span>
                    </p>
                    <div class="form-group">
                        <a href="/api/admin/equivalencies" class="btn btn-outline-primary form-control-file" target="_blank" download="equivalencies.csv">
                            {"⇩ Download Historical Equivalencies"}
                        </a>
                    </div>
                    <div class="form-group">
                        <label class="btn btn-outline-danger form-control-file">
                            {"⇧ Upload Historical Equivalencies"}
                            <input name="equivalencies" type="file" onchange={uploadNewEquivalencies} hidden />
                        </label>
                    </div>
                    {state.equivalenciesMessage ? <h6>{state.equivalenciesMessage}</h6> : <span />}
                    {state.equivalenciesErrors
                        ? (
                            <ol>
                                {state.equivalenciesErrors.map(e => <li class="small text-danger" key={e}>{e}</li>)}
                            </ol>
                        )
                        : <span />
                    }
                    <hr/>
                    <h6 class="text-muted">Backup Database</h6>
                    <p>
                        This tool allows you to download all the student applications into a JSON file. This file can
                        be edited using a text editor such as Notepad++ or Sublime Text on Windows and TextEdit on Mac.
                        <br />
                        <span class="text-danger">
                        Warning: Uploading the file will <b>remove all existing applications</b> from
                        the database, and insert new data for each application in the JSON file.</span>
                    </p>
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
                    {state.applicationsMessage ? <h6>{state.applicationsMessage}</h6> : <span />}
                    {state.applicationsErrors
                        ? (
                            <ol>
                                {state.applicationsErrors.map(e => <li class="small text-danger" key={e}>{e}</li>)}
                            </ol>
                        )
                        : <span />
                    }
                </div>
            </Modal>
        );
    }

    return { view };
}