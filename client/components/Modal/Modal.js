import m from 'mithril';
import classNames from 'classnames'
import ModalStyles from './Modal.css'

export function showModal() {
	$("#Modal").modal(focus = true);
}

$(document).on('hidden.bs.modal', '#Modal', function() { 
	hideModal() 
	m.redraw();
});

// This function is passed in as part of the ModalState
var hideModal = () => {};

export default function ApplicationModal() {

	function oncreate(vnode) {
		hideModal = vnode.attrs.modalData.onclose;
	}

	var modalSize

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