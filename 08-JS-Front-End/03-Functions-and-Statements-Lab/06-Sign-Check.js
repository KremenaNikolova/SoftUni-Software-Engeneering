function multiplication(numOne, numTwo, numThree){
    let minusCount = 0;
    if (numOne < 0) {
        minusCount++;
    }
    if (numTwo < 0) {
        minusCount ++;
    }
    if (numThree < 0) {
        minusCount ++;
    }

    if (minusCount === 0 || minusCount === 2) {
        return console.log(`Positive`);
    } else {
        return console.log(`Negative`);
    }

}

multiplication(
 5,
 12,
-15
)

multiplication(
-6,
-12,
 14
)

multiplication(
-1,
-2,
-3
)

multiplication(
-5,
1,
1
)