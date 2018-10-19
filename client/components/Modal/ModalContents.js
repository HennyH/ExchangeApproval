import m from 'mithril'
import ApplicationForm, { ApplicationPowerForm } from '../ApplicationPage/ApplicationForm.js';
import Spinner from 'Components/Spinners/RectangularSpinner.js';

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
    unitLevelOptions: [{"label":"Zero","value":0,"selected":true},{"label":"One","value":1,"selected":true},{"label":"Two","value":2,"selected":true},{"label":"Three","value":3,"selected":true},{"label":"Four","value":4,"selected":true},{"label":"GtFour","value":5,"selected":true}]
})

function showData() {
    return console.log(applicationPowerForm ? JSON.stringify(applicationPowerForm.getData(), null, 4) : null);
}

export var ApplicationModalContent = {
	oninit: function() {
        if (Data.filters.options === null) {
			Data.filters.fetch();
		}
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
				<div class="modal-body">
					{(Data.filters.loading
						? <Spinner style="top: calc(50% - 32px); left: calc(50% - 32px); position: absolute;" />
						: (
							<ApplicationForm 
								form={applicationPowerForm} 
								staffView = {true} 
							/>
						)
					)}	
				</div>
				<div class="modal-footer">
					<button type="button" class="btn btn-secondary" data-dismiss="modal">Cancel</button>
					<button type="button" class="btn btn-primary" data-dismiss="modal">Save Application</button>
				</div>
			</div>
		);
	}
}
