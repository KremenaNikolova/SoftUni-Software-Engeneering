Writing Web UI Tests

The included REST service comes with following premade user accounts, which you may use for development:
{ "email": "peter@abv.bg", "password": "123456" }
{ "email": "john@abv.bg", "password": "123456" }

Don't forget to start:
'npm install'
'npm install -D @playwright/test'
'npm run start'

Then go to the server folder in the project directory and type command in a CLI or PowerShell
'node server.js'

You cannot log in if you are not connected to the server.js too

Create a "tests" folder in project directory and a new file in it named 'ui.test.js' and willcontain UI tests using Playwright and another one 'api.test.js' which one will contain our Mocha tests.

To exectute the command for running the Playwright test, type command below in the vs terminal
'npx playwright test tests/ui.test.js'


Change package.json file 'scripts' to

' "scripts": {
        "test": "npx playwright test",
        "start-fe": "http-server -a localhost -p 3000 -P http://localhost:3000? -c-1",
        "start-be": "node server/server.js" 
}'

after that u can run 
tests with 'npm run test'
front end with 'npm run start-fe'
back end with 'npm run start-be'
