function holiday(numOfPeople, groupType, weekDay) {
    let totalPrice;

    if (groupType === "Students") {
        if (weekDay === "Friday") {
            totalPrice = numOfPeople * 8.45;
        } else if (weekDay === "Saturday") {
            totalPrice = numOfPeople * 9.80;
        } else if (weekDay === "Sunday") {
            totalPrice = numOfPeople * 10.46
        }

        if (numOfPeople >= 30) {
            totalPrice -= totalPrice * 0.15;
        }

    } else if (groupType === "Business") {
        if (numOfPeople >= 100) {
            numOfPeople -= 10;
        }

        if (weekDay === "Friday") {
            totalPrice = numOfPeople * 10.90;
        } else if (weekDay === "Saturday") {
            totalPrice = numOfPeople * 15.60;
        } else if (weekDay === "Sunday") {
            totalPrice = numOfPeople * 16;
        }

    } else if (groupType === "Regular") {
        if (weekDay === "Friday") {
            totalPrice = numOfPeople * 15;
        } else if (weekDay === "Saturday") {
            totalPrice = numOfPeople * 20;
        } else if (weekDay === "Sunday") {
            totalPrice = numOfPeople * 22.50;
        }

        if (numOfPeople >= 10 && numOfPeople <= 20) {
            totalPrice -= totalPrice * 0.05;
        }
    }

    console.log(`Total price: ${totalPrice.toFixed(2)}`)
}


holiday(30, "Students", "Sunday");
holiday(40, "Regular", "Saturday");