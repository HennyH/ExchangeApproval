import m from 'mithril';

import SearchPage from './src/SearchPage'
import ApplicationPage from './src/ApplicationPage'

(() => {
    m.route(document.body, "/search", {
        "/search": SearchPage,
        "/application": ApplicationPage
    });
})()
