import m from 'mithril';
import ApplicationForm, { ApplicationPowerForm } from "../ApplicationPage/ApplicationForm";
import Spinner from 'Components/Spinners/RectangularSpinner.js';
import classNames from 'classnames'
import Styles from '..ApplicationPage/ApplicationPage.css'

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
    onChange: showData,
    unitLevelOptions: [{"label":"Zero","value":0,"selected":true},{"label":"One","value":1,"selected":true},{"label":"Two","value":2,"selected":true},{"label":"Three","value":3,"selected":true},{"label":"Four","value":4,"selected":true},{"label":"GtFour","value":5,"selected":true}]
})

function showData() {
    return console.log(applicationPowerForm ? JSON.stringify(applicationPowerForm.getData(), null, 4) : null);
}

export default function ApplicationModal() {

	function oninit() {
        if (Data.filters.options === null) {
            Data.filters.fetch();
        }
	}
	
    function view({studentName}) {
        return (
			<div class="modal fade" id="applicationModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
				<div class="modal-dialog modal-dialog-centered modal-lg" role="document">
					<div class="modal-content">
						<div class="modal-header">
							<h5 class="modal-title" id="exampleModalLongTitle">{`Edit Application: ${studentName}`}</h5>
							<button type="button" class="close" data-dismiss="modal" aria-label="Close">
								<span aria-hidden="true">&times;</span>
							</button>
						</div>
						<div class="modal-body">
							{(Data.filters.loading
								? <Spinner style="top: calc(50% - 32px); left: calc(50% - 32px); position: absolute;" />
								: (
									<ApplicationForm form={applicationPowerForm} />
								)
							)}
						</div>
						<div class="modal-footer">
							<button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
							<button type="button" class="btn btn-primary">Save changes</button>
						</div>
					</div>
				</div>
			</div>
        );
    }

	return { view }
}