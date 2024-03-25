const { test, expect } = require("@playwright/test");
const baseUrl = "http://localhost:3000";

//Navigation Bar for Guest Users tests

test('Verify "All Books" link is visible', async ({ page }) => {
  //page property represents the browser page that will be used for the test
  await page.goto(baseUrl);

  await page.waitForSelector("nav.navbar"); //have to wait for navigation bar to load on the web page and then Playwright wait until an element matching the CSS selector

  const allBooksLink = await page.$('a[href="/catalog"]'); //othis is the element representing "All Books" link on the page. Use $ funcation of the page object along with the CSS selector to select the link element

  const isLinkVisible = await allBooksLink.isVisible(); //check "All Books" link is visible on the page

  expect(isLinkVisible).toBe(true);
});

test('Verify "Login" link is visible', async ({ page }) => {
  await page.goto(baseUrl);
  await page.waitForSelector("nav.navbar");

  const loginButton = await page.$('a[href="/login"]');
  const isLoginButtonVisible = await loginButton.isVisible();

  expect(isLoginButtonVisible).toBe(true);
});

test('Verify "Register" link is visible', async ({ page }) => {
  await page.goto(baseUrl);
  await page.waitForSelector("nav.navbar");

  const registerButton = await page.$('a[href="/register"]');
  const isRegisterButtonVisible = await registerButton.isVisible();

  expect(isRegisterButtonVisible).toBe(true);
});
