const webdriverio = require('webdriverio');

const getChromeOptions = () => ({
    desiredCapabilities: {
        browserName: 'chrome',
        chromeOptions: {
            args: [
                ...(process.env.NO_HEADLESS ? [] : ['headless']),
                'disable-gpu',
                'no-sandbox',
                'window-size=1280x1024'
            ]
        }
    }
});

export function syncGetBrowser() {
    const options = getChromeOptions();
    return webdriverio.remote(options).init();
};
