import m from 'mithril'
import ApplicationForm, { ApplicationPowerForm } from '../ApplicationPage/ApplicationForm.js';
import Spinner from 'Components/Spinners/RectangularSpinner.js';

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
            url: "/admin/equivalencies",
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
                    <h5 class="modal-title" id="ModalTitle">Edit Unit Equivalencies</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <button type="button" class="btn btn-outline-primary form-control-file">
                            {"⇩ Download Equivalencies"}
                        </button>
                    </div>
                    <div class="form-group">

                        <label class="btn btn-outline-danger form-control-file">
                            {"⇧ Upload New Equivalencies"}
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
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary" data-dismiss="modal">Save changes</button>
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
                            <input class="form-control" type="password" placeholder="Password" name="Password" />
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

const applicationPowerForm = new ApplicationPowerForm({
    staffView: true,
    onChange: showData,
    unitLevelOptions: [{ "label": "Zero", "value": 0, "selected": true }, { "label": "One", "value": 1, "selected": true }, { "label": "Two", "value": 2, "selected": true }, { "label": "Three", "value": 3, "selected": true }, { "label": "Four", "value": 4, "selected": true }, { "label": "GtFour", "value": 5, "selected": true }]
})

function showData() {
    return console.log(applicationPowerForm ? JSON.stringify(applicationPowerForm.getData(), null, 4) : null);
}

export var ApplicationModalContent = {
    oninit: function () {
        if (Data.filters.options === null) {
            Data.filters.fetch();
        }
        EmailData.Form=applicationPowerForm;
    },

    view: function ({ attrs: { title } }) {
        return (
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="ModalTitle">{title}</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
				<div class="modal-body p-0">
                    {(Data.filters.loading
                        ? <Spinner style="top: calc(50% - 32px); left: calc(50% - 32px); position: absolute;" />
                        : (
							<ApplicationForm class="m-0 p-0"
                                form={applicationPowerForm}
                                staffView={true}
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
