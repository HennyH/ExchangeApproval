import m from 'mithril';
import classNames from 'classnames'
import ModalStyles from './Modal.css'
import {ModalState} from '../ViewData'

const noop = () => {}

export default function Modal() {

    function oncreate({ dom: ref, attrs: { onClose = noop } }) {
        $(ref).modal();
        $(ref).on('hidden.bs.modal', function() {
            onClose();
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
