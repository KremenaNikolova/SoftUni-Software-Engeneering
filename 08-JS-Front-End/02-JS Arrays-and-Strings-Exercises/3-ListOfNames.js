function solve(array) {
    array.sort((a, b) => a.localeCompare(b));

    let counter = 0;
    for (const element of array) {
        counter++;
        console.log(counter + '.' + element);
    }
}

solve(['John', 'Bob', 'Christina', 'Ema']);