import m from 'mithril';

import SearchPage from 'SearchPage';
import ApplicationPage from 'ApplicationPage';

(() => {
    m.route(document.body, "/search", {
        "/search": SearchPage,
        "/application": ApplicationPage
    });
})()
