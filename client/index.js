import m from 'mithril';

import SearchPage from 'Components/SearchPage';
import ApplicationPage from 'Components/ApplicationPage';
import StudentOfficePage from 'Components/StaffPage';

window.LOGGED_IN = false;

(() => {
    m.route(document.body, "/search", {
        "/search": SearchPage,
        "/application": ApplicationPage,
        "/student-office": {
            onmatch: function () {
                return m.request("/api/admin/login").then(
                    () => {
                        window.LOGGED_IN = true;
                        return StudentOfficePage;
                    },
                    () => {
                        window.LOGGED_IN = false;
                        return SearchPage;
                    }
                );
            }
        }
    });
})()
