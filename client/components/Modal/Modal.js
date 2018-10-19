import m from 'mithril';
import classNames from 'classnames'
import ModalStyles from './Modal.css'

export const ModalState = {
	downloadModal: false,
	selectedApplication: null,
	onHide: () => {},
	// student: null,
	// exchangeUniversity: null,
	// unitsets: null,
	// // fetch: () => 
}

export function showDownloadModal() {
	ModalState.downloadModal = true;
	ModalState.onHide = () => {ModalState.downloadModal = false}
	m.redraw();
}

export function showApplicationModal(decision) {
	ModalState.selectedApplication = decision;
	ModalState.onHide = () => {ModalState.selectedApplication = null}
	// ModalState.fetch();
	m.redraw();
}

export default function Modal() {

	var hideModal = () => {};

	function oncreate({dom: ref}) {
		( function showModal() {$(ref).modal(focus = true)}() );
		hideModal = ModalState ? ModalState.onHide : {};
		$(ref).on('hidden.bs.modal', function() { 
			hideModal(); 
			m.redraw();
		});
	}

    function view({ attrs: {size}, children}) {
        return (
			<div class="modal fade" id="Modal" tabindex="-1" role="dialog" aria-labelledby="Modal" aria-hidden="true">
				<div 
					class= {classNames((size == 'xl' ? ModalStyles.modalXl : (size == 'lg' ? 'modal-lg' : 'modal-sm')), "modal-dialog modal-dialog-centered")} 
					role="document"
				>
					{children}
				</div>
			</div>
        );
    }

	return { view, oncreate }
}
