function sum(number){
    let numArray = number.toString();
    let evenSum = 0;
    let oddSum = 0;

    for (let i = 0; i < numArray.length; i++) {
        let currNumber = Number (numArray[i]);

        if (currNumber % 2 === 0) {
            evenSum += currNumber;
        } else {
            oddSum += currNumber;
        }
    }

    console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`)

}

sum(1000435);

sum(3495892137259234);