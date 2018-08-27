import m from 'mithril';

import SearchPage from './src/SearchPage'


(() => {
    let root = document.body;
    m.mount(
        root,
        SearchPage
    );
})()
