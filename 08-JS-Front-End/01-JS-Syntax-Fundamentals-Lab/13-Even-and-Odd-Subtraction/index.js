function solve(arr){
    let evensSum = 0;
    let oddsSum = 0;
    for (let index = 0; index < arr.length; index++) {
        if (arr[index] % 2 === 0) {
            evensSum += arr[index];
        } else {
            oddsSum += arr[index];
        }
    }

    let total = evensSum - oddsSum;
    console.log(total);
}

solve([1,2,3,4,5,6]);
solve([3,5,7,9]);
solve([2,4,6,8,10]);