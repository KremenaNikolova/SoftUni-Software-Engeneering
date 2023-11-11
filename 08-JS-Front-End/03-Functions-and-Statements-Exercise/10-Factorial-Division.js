function factorialDivision(numOne, numTwo){
    let firstNumFactorial = 1;
    for (let i = numOne; i > 1; i--) {
        firstNumFactorial = firstNumFactorial * i;
    }

    let secondNumFactorial = 1;
    for (let j = numTwo; j >1; j--) {
        secondNumFactorial = secondNumFactorial*j;
    }

    let result =(firstNumFactorial / secondNumFactorial).toFixed(2);

    console.log(result);
};

factorialDivision(5, 2);
factorialDivision(6, 2);