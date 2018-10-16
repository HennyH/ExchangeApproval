import m from 'mithril';
import classNames from 'classnames'

import Styles from './Layout.css';

export default function Layout() {
    function view({ children }) {
        const currentRoute = m.route.get();
        const navLinks = [
            { href: "/search", text: "Search Units" },
            { href: "/application", text: "Student Application" },
            { href: "/student-office", text: "Staff Portal" }
        ];
        return (
            <div>
                <nav class="navbar navbar-expand-lg navbar-light bg-light">
                    <a class="navbar-brand" href="#">
                        <div class={classNames(Styles.uwaLogo, "d-inline-block", "align-middle")}></div>
                        UWA Exchange Helper
                    </a>
                    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavAltMarkup" aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="collapse navbar-collapse" id="navbarNavAltMarkup">
                        <div class="navbar-nav">
                            {navLinks.map(({ href, text }) => {
                                const isActive = href === currentRoute;
                                const classes = classNames("nav-item nav-link", isActive ? "active" : "");
                                return (
                                    <a oncreate={m.route.link} href={href} class={classes}>
                                        {text}
                                        { isActive ? <span class="sr-only">(current)</span> : <span /> }
                                    </a>
                                );
                            })}
                        </div>
                    </div>
                </nav>
                {children}
            </div>
        )
    }

    return { view };
}