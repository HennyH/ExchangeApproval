import m from 'mithril'

export function DownloadModalContents() {

	function view() {
		return (
			<form>
				<button type="button" class="btn btn-outline-primary">Download Faculty List</button>
				<div class="form-group">
					<label for="UploadCSV">Upload Faculty List</label>
					<input type="file" class="form-control-file" id="UploadCSV"/>
				</div>
			</form >
		);
	}
	return (view);
}