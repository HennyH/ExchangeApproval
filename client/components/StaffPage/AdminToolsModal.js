import m from 'mithril';
import classNames from 'classnames'
import Modal from '../Modal/Modal.js';

export default function AdminToolsModal() {

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
                                    {state.errors.map(e => <li class="small text-danger" key={e}>{e}</li>)}
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
            </Modal>
        );
    }

    return { view };
}