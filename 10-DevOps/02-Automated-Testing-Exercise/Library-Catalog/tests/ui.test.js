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

//Navigation Bar for Logged-In Users tests

test('Verify "All Books" link is visible after user login', async ({
  page,
}) => {
  await page.goto(baseUrl + "/login");

  await page.fill('input[name="email"]', "peter@abv.bg");
  await page.fill('input[name="password"]', "123456");
  await page.click('input[type="submit"]');

  const allBooksLink = await page.$('a[href="/catalog"]');
  const isAllBooksLinkVisible = await allBooksLink.isVisible();

  expect(isAllBooksLinkVisible).toBe(true);
});

test('Verify "My Books" link is visible after user login', async ({ page }) => {
  await page.goto(baseUrl + "/login");

  await page.fill('input[name="email"]', "peter@abv.bg");
  await page.fill('input[name="password"]', "123456");
  await page.click('input[type="submit"]');

  const myBooksLink = await page.$('a[href="/profile"]');
  const isMyBooksLinkVisible = await myBooksLink.isVisible();

  expect(isMyBooksLinkVisible).toBe(true);
});

test('Verify "Add Books" link is visible after user login', async ({
  page,
}) => {
  await page.goto(baseUrl + "/login");

  await page.fill('input[name="email"]', "peter@abv.bg");
  await page.fill('input[name="password"]', "123456");
  await page.click('input[type="submit"]');

  const addBooksLink = await page.$('a[href="/create"]');
  const isAddLinkVisible = await addBooksLink.isVisible();

  expect(isAddLinkVisible).toBe(true);
});

test("Verify User Email Address is visible after user login", async ({
  page,
}) => {
  await page.goto(baseUrl + "/login");

  await page.fill('input[name="email"]', "peter@abv.bg");
  await page.fill('input[name="password"]', "123456");
  await page.click('input[type="submit"]');

  const userEmail = await page.$("#user > span");
  const isuserEmailVisible = await userEmail.isVisible();

  expect(isuserEmailVisible).toBe(true);
});
