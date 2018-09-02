import m from 'mithril';
import classNames from 'classnames'

import Styles from './Layout.css';

export default function Layout() {
    function view({ children }) {
        return (
            <div>
                <nav class="navbar sticky-top navbar-expand-lg navbar-light bg-light">
                    <a class="navbar-brand" href="#">
                        <div class={classNames(Styles.uwaLogo, "d-inline-block", "align-middle")}></div>
                        UWA Exchange Helper
                    </a>
                    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavAltMarkup" aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="collapse navbar-collapse" id="navbarNavAltMarkup">
                        <div class="navbar-nav">
                        <a class="nav-item nav-link active" href="#!/search">Search <span class="sr-only">(current)</span></a>
                        <a class="nav-item nav-link" href="#!/application">Apply</a>
                        <a class="nav-item nav-link" href="#">Staff</a>
                        </div>
                    </div>
                </nav>
                {children}
            </div>
        )
    }

    return { view };
}