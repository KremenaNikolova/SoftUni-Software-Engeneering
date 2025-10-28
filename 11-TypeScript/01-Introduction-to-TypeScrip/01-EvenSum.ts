function isEvenSum (num1: number, num2: number, num3: number) : boolean {
    let result: number;
    result = num1 + num2 + num3;
    
    if (result % 2 === 0) {
        return true;
    }
    return false;
}

console.log(isEvenSum(1, 2, 3)); //true
console.log(isEvenSum(2, 2, 3)) //false