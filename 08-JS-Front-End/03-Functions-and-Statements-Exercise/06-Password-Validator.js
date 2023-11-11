function passwordCheck(string){
    let isValid = true;

    if (string.length < 6 || string.length > 19) {
        console.log(`Password must be between 6 and 10 characters`);
        isValid = false;
    }

    if (!string.match("^[A-Za-z0-9]+$")) {
        console.log(`Password must consist only of letters and digits`);
        isValid = false;
    }

    let numbersInString = string.replace(/[^0-9]/g,"").length;
    if ( numbersInString < 2) {
        console.log(`Password must have at least 2 digits`);
        isValid = false;
    }

    if (isValid) {
        console.log(`Password is valid`);
    }
}

passwordCheck('logIn');

passwordCheck('MyPass123');

passwordCheck('Pa$s$s');