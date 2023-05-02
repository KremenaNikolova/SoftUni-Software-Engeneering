function simpleCalculator(firstNum, secondNum, operator){
    const add = (firstNum, secondNum) => firstNum + secondNum;
    const subtract = (firstNum, secondNum) => firstNum - secondNum;
    const multiply = (firstNum, secondNum) => firstNum * secondNum;
    const divide = (firstNum, secondNum) => firstNum / secondNum;
    // const operationMap = {
    //     add: add,
    //     subtract: subtract,
    //     divide: divide,
    //     multiply: multiply
    // }
    
    // return operationMap[operator](firstNum, secondNum);

    switch(operator){
        case "multiply": return multiply(firstNum, secondNum); 
        case "divide": return divide(firstNum, secondNum);
        case "add": return add(firstNum, secondNum);
        case "subtract": return subtract(firstNum, secondNum);
    }
}

console.log(simpleCalculator(
    5,
    5,
    'multiply'
    ));

console.log(simpleCalculator(
    40,
    8,
    'divide'
));

console.log(simpleCalculator(
    12,
    19,
    'add'
    ));

console.log(simpleCalculator(
    50,
    13,
    'subtract'
));