function solve(startingYield) {
    let daysCount = 0;
    let totalSpices = 0;
    for (let i = startingYield; i >= 100; i -= 10){
        daysCount++;
        totalSpices += i - 26;
    }
    totalSpices -= 26;

    if (totalSpices < 0) {
        totalSpices = 0;
    }
    
    console.log(daysCount);
    console.log(totalSpices);
}

solve(111);
solve(450);