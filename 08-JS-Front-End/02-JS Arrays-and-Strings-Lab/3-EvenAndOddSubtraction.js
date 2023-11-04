function solve(numArray) {
    let oddSum = 0;
    let evenSum = 0;
    let result = 0;

    for (const num of numArray) {
        if (num % 2 === 0) {
            evenSum += num;
        } else {
            oddSum += num;
        }
    }

    result = evenSum - oddSum;

    console.log(result);
}

solve([1, 2, 3, 4, 5, 6,]);
solve([3, 5, 7, 9]);
solve([2, 4, 6, 8, 10]);