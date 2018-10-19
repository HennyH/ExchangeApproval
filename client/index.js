import m from 'mithril';

import SearchPage from 'Components/SearchPage';
import ApplicationPage from 'Components/ApplicationPage';
import StudentOfficePage from 'Components/StaffPage';
import Login from 'Components/Login';

(() => {
    m.route(document.body, "/search", {
        "/search": SearchPage,
        "/application": ApplicationPage,
        "/student-office": {
			onmatch: function() {
				if (!window.isLoggedIn) m.route.set("/login")
				else return StudentOfficePage
			}
		},
		"/login": Login
    });
})()
