import m from 'mithril'

export var DownloadModalContent = {
	view: function() {
		return (
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
		);
	}
}

export var LoginModalContent = {
	view: function() {
		return (
			<form>
				<div class="form-group">
					<input class="form-control" type="password" placeholder="Password" name ="Password"/>
				</div>
			</form >
		);
	}
}