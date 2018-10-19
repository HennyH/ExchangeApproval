import m from 'mithril';
import classNames from 'classnames'
import {showDownloadModal} from '../Modal/Modal'

import Styles from './Layout.css';

var Navbar = {
	view: function(vnode) {
		const currentRoute = m.route.get();
        const navLinks = [
            { href: "/search", text: "Search Units" },
            { href: "/application", text: "Student Application" },
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
							const isActive = href === currentRoute;
							const classes = classNames("nav-item nav-link", isActive ? "active" : "");
							return (
								<li oncreate={m.route.link} href={href} class={classes}>
									{text}
									{ isActive ? <span class="sr-only">(current)</span> : <span /> }
								</li>
							);
						})}
					</ul>
					<ul class="navbar-nav ml-auto">
						{vnode.attrs.showNavDropdown ? 
							<li class="dropdown">
								<a class="nav-link dropdown-toggle" data-toggle="dropdown" href="#" role="button" aria-haspopup="true" aria-expanded="false">Admin</a>
								<div class="dropdown-menu dropdown-menu-right">
									<button class="dropdown-item" onclick={showDownloadModal}>Download / Upload Faculty List</button>
									<div class="dropdown-divider"></div>
									<button class="dropdown-item" href="#">Log Out</button>
								</div>
							</li>
						: null}
					</ul>
				</div>
			</nav>
		);
	}
}

export default function Layout() {
    function view({ attrs: { showNavDropdown = false }, children }) {
        return (
            <div>
                <Navbar showNavDropdown = {showNavDropdown}/>
				{children}
            </div>
        )
    }
    return { view }
}