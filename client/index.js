import m from 'mithril';

import SearchPage from 'Components/SearchPage';
import ApplicationPage from 'Components/ApplicationPage';

(() => {
    m.route(document.body, "/search", {
        "/search": SearchPage,
        "/application": ApplicationPage
    });
})()
