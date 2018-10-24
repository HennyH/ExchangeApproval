import m from 'mithril';
import classNames from 'classnames'
import ModalStyles from './Modal.css'
import {ModalState} from '../ViewData'

const noop = () => {}

export default function Modal() {

    const state = { $ref: null };

    function oncreate({ dom: ref, attrs: { onClose = noop } }) {
        state.$ref = $(ref);
        state.$ref.on('hidden.bs.modal', function() {
            onClose();
            m.redraw();
        });
        showModal();
    }

    function showModal() {
        if (!state.$ref) {
            return;
        }
        if (!state.$ref.hasClass('show.bs.modal') && !state.$ref.hasClass('shown.bs.modal')) {
            state.$ref.modal();
        }
    }

    function view({ attrs: { size, title, header, footer }, children}) {
        showModal();
        const headerContent = header || ([
                <h5 class="modal-title" id="ModalTitle">{title}</h5>,
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
        ])
        return (
            <div class="modal fade" id="Modal" tabindex="-1" role="dialog" aria-labelledby="Modal" aria-hidden="true">
                <div
                    class= {classNames((size == 'xl' ? ModalStyles.modalXl : (size == 'lg' ? 'modal-lg' : 'modal-sm')), "modal-dialog modal-dialog-centered")}
                    role="document"
                >
                    <div class="modal-content">
                        <div class="modal-header">
                            {headerContent}
                        </div>
                        <div class="modal-body p-0">
                            {children}
                        </div>
                        {footer && (
                            <div class="modal-footer d-flex justify-content-between">
                                {footer}
                            </div>
                        )}
                    </div>
                </div>
            </div>
        );
    }

    return { view, oncreate }
}
