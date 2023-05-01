function input(firstNum, secondNum, mathOperation){
    let result = 0;
    switch(mathOperation){
        case '+': result = firstNum + secondNum; break;
        case '-': result = firstNum - secondNum; break;
        case '*': result = firstNum * secondNum; break;
        case '/': result = firstNum / secondNum; break;
        case '%': result = firstNum % secondNum; break;
        case '**': result = firstNum ** secondNum; break;
        default: 'Error!'; break;
    }

    console.log(result);
}

input(5, 6, '+');
input(3, 5.5, '*');

