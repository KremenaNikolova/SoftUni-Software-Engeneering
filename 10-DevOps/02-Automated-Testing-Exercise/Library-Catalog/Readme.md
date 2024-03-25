Writing Web UI Tests

The included REST service comes with following premade user accounts, which you may use for development:
{ "email": "peter@abv.bg", "password": "123456" }
{ "email": "john@abv.bg", "password": "123456" }

Don't forget to start:
<br/>
```npm install```
<br/>
```npm install -D @playwright/test```
<br/>
```npm run start```
<br/>

Then go to the server folder in the project directory and type command in a CLI or PowerShell
<br/>
```node server.js```
<br/>

You cannot log in if you are not connected to the server.js too
<br/>

Create a "tests" folder in project directory and a new file in it named 'ui.test.js' and willcontain UI tests using Playwright and another one 'api.test.js' which one will contain our Mocha tests.
<br/>

To exectute the command for running the Playwright test, type command below in the vs terminal
<br/>
```npx playwright test tests/ui.test.js```
<br/>


Change package.json file 'scripts' to
<br/>

```
 "scripts": {
        "test": "npx playwright test",
        "start-fe": "http-server -a localhost -p 3000 -P http://localhost:3000? -c-1",
        "start-be": "node server/server.js" 
}
 ```
<br/>

after that u can run 
<br/>
tests with ```npm run test```
<br/>
front end with ```npm run start-fe```
<br/>
back end with ```npm run start-be```
<br/>
