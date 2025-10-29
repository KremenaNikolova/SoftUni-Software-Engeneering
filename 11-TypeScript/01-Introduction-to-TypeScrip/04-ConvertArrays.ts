function ConvertArrays(words: string[]): [string, number] {

    let convertedArray: string = '';
    let counter: number = 0;

    for (let i = 0; i < words.length; i++){
        convertedArray += words[i];
    }
    counter = convertedArray.length;
    return [convertedArray, counter];
}

console.log(ConvertArrays(['How', 'are', 'you?']));
console.log(ConvertArrays(['Today', ' is', ' a ', 'nice', ' ', 'day for ', 'TypeScript']));