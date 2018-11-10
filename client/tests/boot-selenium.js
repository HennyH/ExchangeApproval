import promisify from 'promisify-node';
import selenium from 'selenium-standalone';
import ps from 'ps-node';

async function killExistingSelenium() {
  console.log('-- Stopping any existing selenium instances');
  const procs = await promisify(ps.lookup)({
    command: 'java',
    arguments: /.*selenium-standalone.*/
  });
  const $kills = procs.map(proc => promisify(ps.kill)({ pid: proc.pid }));
  await Promise.all($kills);
}

function installSelenium(opts) {
  console.log('-- Installing selenium drivers');
  return promisify(selenium.install)(opts);
}

function startSelenium(opts) {
  console.log('-- Booting selenium');
  return promisify(selenium.start)({
    stdio: 'inherit',
    ...opts
  });
}

export default async function bootSelenium(killExisting) {
  const opts = {
    version: '3.14.0',
    drivers: {
      chrome: {
        version: '2.43',
        arch: process.arch,
        baseURL: 'https://chromedriver.storage.googleapis.com'
      }
    }
  };

  if (killExisting) {
    try {
      await killExistingSelenium();
    } catch (e) {
      console.error(`Error killing selenium instances (this functionality doesn't work well on windows!): ${e}`);
      console.error(e.stack);
    }
  }
  try {
    await installSelenium(opts);
  } catch (e) {
    console.error(`Could not install selenium components: ${e}`);
    console.error(e.stack);
    throw e;
  }

  try {
    await startSelenium(opts);
  } catch (e) {
    console.error(`Could not start selenium: ${e}`);
    console.error(e.stack);
    throw e;
  }
}
