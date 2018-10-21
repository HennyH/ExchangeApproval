import m from 'mithril';

import SearchPage from 'Components/SearchPage';
import ApplicationPage from 'Components/ApplicationPage';
import StudentOfficePage from 'Components/StaffPage';

(() => {
    m.route(document.body, "/search", {
        "/search": SearchPage,
        "/application": ApplicationPage,
        "/student-office": {
            onmatch: function () {
                return m.request("/login").then(() => StudentOfficePage, (() => SearchPage));
            }
        }
    });
})()
