function solve(text, word){
    let count = 0;
    let textArr = text.split(' ');

    for (let i = 0; i < textArr.length; i++) {
        if (textArr[i] === word) {
            count ++;
        }
    }

    console.log(count)
}

solve('This is a word and it also is a sentence', 'is')
solve('softuni is great place for learning new programming languages', 'softuni')