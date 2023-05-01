function solve(text, word){
    // let consoreSymbol = '*';
    // let censore = '*'.repeat(word.length);

    let censored = text.replace(word, '*'.repeat(word.length));
    while (censored.includes(word)) {
        censored = text.replace(word, '*'.repeat(word.length));
    }

    console.log(censored);
}

solve('A small sentence with some words', 'small');
solve('Find the hidden word', 'hidden');