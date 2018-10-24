import m from 'mithril';
import classNames from 'classnames'
import { DownloadModalContent } from '../Modal/ModalContents.js';
import Modal from '../Modal/Modal.js';

import Styles from './Layout.css';

function Navbar() {

    const state = { showAdminModal: false };

    function toggleAdminModal() {
        state.showAdminModal = !state.showAdminModal;
        m.redraw();
    }

    function view(vnode) {
        const currentRoute = m.route.get();
        const navLinks = (vnode.attrs.staff ? 
        [
            { href: "/student-office", text: "Application Inbox" },
            { href: "/search", text: "Search Units" },
        ]:
        [
            { href: "/application", text: "Student Application" },
            { href: "/search", text: "Search Units" },
        ]);
        return(
            <nav class="navbar navbar-expand-lg navbar-light bg-light">
                <a class="navbar-brand" href="#">
                    UWA Exchange Helper
                </a>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarCollapsable" aria-controls="navbarCollapsable" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarCollapsable">
                    <ul class="navbar-nav">
                        {navLinks.map(({ href, text }) => {
                            const isActive = href === currentRoute;
                            const classes = classNames("nav-item nav-link", isActive ? "active" : "");
                            return (
                                <li oncreate={m.route.link} style="cursor: pointer;" href={href} class={classes}>
                                    {text}
                                    { isActive ? <span class="sr-only">(current)</span> : <span /> }
                                </li>
                            );
                        })}
                    </ul>
                    <ul class="navbar-nav ml-auto">
                        <li class="dropdown">
                            <a class="nav-link dropdown-toggle" data-toggle="dropdown" href="#" role="button" aria-haspopup="true" aria-expanded="false">Staff</a>
                            <div class="dropdown-menu dropdown-menu-right">
                                {vnode.attrs.staff ?
                                    <button class="dropdown-item" onclick={toggleAdminModal}>Download / Upload Faculty List</button>
                                :    <button class="dropdown-item" oncreate={m.route.link} href="/student-office">Log In</button>
                                }
                            </div>
                        </li>
                    </ul>
                </div>
                {state.showAdminModal && (
                    <Modal onClose={toggleAdminModal}>
                        <DownloadModalContent />
                    </Modal>
                )}
            </nav>
        );
    }

    return { view }
}

export default function Layout() {
    function view({ attrs: { staff = false }, children }) {
        return (
            <div>
                <Navbar staff = {staff}/>
                {children}
            </div>
        )
    }
    return { view }
}