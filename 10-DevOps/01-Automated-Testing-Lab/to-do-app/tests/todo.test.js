//test files always at the end must be something.test.js
//this tests are with Playwright so we must install it
//npm install -D @playwright/test
//if test doesnt work try ---> npx playwright install
//to run test ---> npx playwright test

const { test, expect } = require("@playwright/test"); //to import the test and expect functions from the Playwright Test library, we use this code

test("user can add a task", async ({ page }) => {
  //it has description "user can add a task" and an asynchronous function thet runs the test
  await page.goto("http://localhost:5500/"); //then we navigate To-Do app. Note that the port may be different.

  await page.fill("#task-input", "Test Task"); //we fill the task inout with the text 'Test Task'

  await page.click("#add-task"); //and click the [Add Task] button, which should add the new task

  const taskText = await page.textContent(".task"); //get the text content of the first element with class .task. After the [Add Task] button is clicked, this should be the task that was just added

  expect(taskText).toContain("Test Task"); //it checks that the next of the added task includes 'Test Task'. If it does, the test passes. If it doesn't, the test fails;
});

test("user can delete a task", async ({ page }) => {
  await page.goto("http://localhost:5500/");
  await page.fill("#task-input", "Test Task");
  await page.click("#add-task");

  await page.click(".task .delete-task"); //add a line that click te [Delete] button of the task. The task should be removed from the list

  const task = await page.$$eval(
    ".task",
    (
      task //check that the text of the first task doesn't include 'Test Task' anymore.
    ) => task.map((task) => task.textContent)
  );
  expect(task).not.toContain("Test Task");
});

test("user can mark a task as complete", async ({ page }) => {
  await page.goto("http://localhost:5500/");
  await page.fill("#task-input", "Test Task");
  await page.click("#add-task");

  await page.click(".task .task-complete"); //add a line that clicks on the [Complete] button of the tas. Th task should be marked as complete

  const completedTask = await page.$(".task.completed"); //write a line that finds the first element with the class .task.completed

  expect(completedTask).not.toBeNull(); //check that completedTask is not null
});

test('user can filter tasks', async ({ page }) => {
  await page.goto("http://localhost:5500/");
  await page.fill("#task-input", "Test Task");
  await page.click("#add-task");

  await page.click('.task', '.task-complete') //change the selected option of the filter to 'Completed' so list will show only completed tasks

  await page.selectOption('#filter', 'Completed'); //find first task that is not marked as complete

  const incompleteTask = await page.$('.task:not(.completed)'); //check that incompleteTask is null
  expect(incompleteTask).toBeNull();

});
