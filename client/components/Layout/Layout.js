import m from 'mithril';
import classNames from 'classnames'
import {ModalState} from '../ViewData'

import Styles from './Layout.css';

var Navbar = {
    view: function(vnode) {
        const currentRoute = m.route.get();
        const navLinks = [
            { href: "/application", text: "Student Application" },
            { href: "/search", text: "Search Units" },
            { href: "/student-office", text: "Staff Portal" }
        ];
        return(
            <nav class="navbar navbar-expand-lg navbar-light bg-light">
                <a class="navbar-brand" href="#">
                    <div class={classNames(Styles.uwaLogo, "d-inline-block", "align-middle")}></div>
                    UWA Exchange Helper
                </a>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarCollapsable" aria-controls="navbarCollapsable" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarCollapsable">
                    <ul class="navbar-nav">
                        {navLinks.map(({ href, text }) => {
                            const isHidden = href === "/student-office" && !vnode.attrs.staff;
                            const isActive = href === currentRoute;
                            const classes = classNames("nav-item nav-link", isActive ? "active" : "", isHidden ? "d-none" : "");
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
                                    <button class="dropdown-item" onclick={ModalState.DownloadModal.show}>Download / Upload Faculty List</button>
                                :    <button class="dropdown-item" oncreate={m.route.link} href="/student-office">Log In</button>
                                }
                            </div>
                        </li>
                    </ul>
                </div>
            </nav>
        );
    }
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