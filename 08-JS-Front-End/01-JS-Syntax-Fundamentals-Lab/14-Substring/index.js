function solve(letter, startIndex, count){
    let result = letter.substring(startIndex, count + startIndex);

    console.log(result);
}

solve('ASentence', 1, 8);
solve('SkipWord', 4, 7);