import 'mocha';
import assert from 'assert';
import bootSelenium from './boot-selenium.js';
import { syncGetBrowser } from './wd-browser.js';

setTimeout(async function() {

    if (!process.env.SELENIUM_RUNNING) {
        await bootSelenium(true);
    }

    describe("Student Application", function() {

        this.timeout(5 /* min */ * 60 /* seconds */ * 1000 /* ms */);

        it("title should be UWA Exchange Unit Search", async function() {
            const browser = syncGetBrowser();
            try {
                await browser.url("http://localhost:50325");
                const title = await browser.getTitle();
                assert.equal(title, "UWA Exchange Unit Search");
                console.log(title);
            } finally {
                try { await browser.end(); } catch (e) { console.error(e); }
            }
        })
    });

    run();
}, 0)
