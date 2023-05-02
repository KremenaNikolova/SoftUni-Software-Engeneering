function sum(numOne, numTwo, numThree){
    let sumResult = numOne + numTwo;

    function substrack(sumResult, numThree){
        return sumResult - numThree;
    }

    console.log(substrack(sumResult, numThree));
}

sum(23,
    6,
    10
    );

sum(1,
    17,
    30
    );

sum(42,
    58,
    100
    );