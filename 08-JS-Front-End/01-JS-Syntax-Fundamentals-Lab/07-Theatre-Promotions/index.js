function input(typeOfDay, age){
    let ticketPrice = 0;
    if(typeOfDay === "Weekday"){
        if (age>=0 && age<=18) {
            ticketPrice = 12;
        }
        else if (age>18 && age<=64) {
            ticketPrice = 18;
        }
        else if (age>64 && age<=122) {
            ticketPrice = 12;
        }
        else {
            return console.log("Error!");
        }
    }
    else if (typeOfDay === "Weekend"){
        if (age>=0 && age<=18) {
            ticketPrice = 15;
        }
        else if (age>18 && age<=64) {
            ticketPrice = 20;
        }
        else if (age>64 && age<=122) {
            ticketPrice = 15;
        }
        else {
            return console.log("Error!");
        }
    }
    else if (typeOfDay === "Holiday"){
        if (age>=0 && age<=18) {
            ticketPrice = 5;
        }
        else if (age>18 && age<=64) {
            ticketPrice = 12;
        }
        else if (age>64 && age<=122) {
            ticketPrice = 10;
        }
        else {
            return console.log("Error!");
        }
    }

    console.log(`${ticketPrice}$`)
}


input('Weekday', 42);
input('Holiday', -12);
input('Weekday', 15)
