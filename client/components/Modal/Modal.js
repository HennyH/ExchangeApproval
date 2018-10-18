import m from 'mithril';
import classNames from 'classnames'
import ModalStyles from './Modal.css'

export function showModal() {
	$("#Modal").modal(focus = true);
}

// This function is defined by vnode.attrs
var hideModal = () => {};

export default function Modal() {

	function oncreate({attrs: {modalData}, dom: ref}) {
		hideModal = modalData ? modalData.onclose : {};
		
		$(ref).on('hidden.bs.modal', function() { 
			hideModal() 
			m.redraw();
		});
	}

    function view({ attrs: {title, size}, children}) {
        return (
			<div class="modal fade" id="Modal" tabindex="-1" role="dialog" aria-labelledby="Modal" aria-hidden="true">
				<div 
					class= {classNames((size == 'xl' ? ModalStyles.modalXl 
											: (size == 'lg' ? 'modal-lg' : 'modal-sm')), "modal-dialog modal-dialog-centered")} 
					role="document"
					>
					<div class="modal-content">
						<div class="modal-header">
							<h5 class="modal-title" id="ModalTitle">{title}</h5>
							<button type="button" class="close" data-dismiss="modal" aria-label="Close">
								<span aria-hidden="true">&times;</span>
							</button>
						</div>
						<div class="modal-body">
							{children}
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

	return { view, oncreate }
}

// CHANGE EVENT CLICK HANDLER TO DOM REF
// oncreate({ ref }) {
// 	$(ref).on('hidden.bs.model');
// }

// THIS IS CALLED FROM STAFF PAGE
// <ApplicationFormSubmitter>
// 	{({ handleSubmit }) => (
// 		<Modal onSubmit={handleSubmit}>
// 			<ApplicationForm />
// 		</Modal>
// 	)}
// </ApplicationFormSubmitter>

// THIS IS CALLED FROM APPLICATION PAGE
// <ApplicationFormSubmitter>
// 	{
// 		({ handleSubmit }) => (
// 			<div>
// 				<ApplicationForm />
// 				<button type="submit" onclick={handleSubmit} />
// 			</div>
// 		)
// 	}
	
// </ApplicationFormSubmitter>


// // APPLICATION SUB
// export default function ApplicationFormSubmitter() {

// 	function submitToServer(applicationData) {
// 		fetch("/application", "POST", fancyLogic(applicationData));
// 	}

// 	function view({ children }) {
// 		return children({ handleSubmit: submitToServer })
// 	}
// }
