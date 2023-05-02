function smallestNumber(numOne, numTwo, numThree){
    let smallestNumber = Number.MAX_SAFE_INTEGER;
    if (smallestNumber > numOne 
        && numOne < numTwo 
        && numOne < numThree) {
        smallestNumber = numOne
    } else if (smallestNumber > numTwo 
        && numTwo < numOne 
        && numTwo < numThree) {
        smallestNumber = numTwo
    } else if (smallestNumber > numThree 
        && numThree < numOne 
        && numThree < numTwo) {
        smallestNumber = numThree
    } else {
        smallestNumber = numOne;
    }

    console.log(smallestNumber);
}

smallestNumber(
    2,
    5,
    3
    );

smallestNumber(
    600,
    342,
    123
    );

smallestNumber(
    25,
    21,
    4
    );

smallestNumber(
    2,
    2,
    2
    );