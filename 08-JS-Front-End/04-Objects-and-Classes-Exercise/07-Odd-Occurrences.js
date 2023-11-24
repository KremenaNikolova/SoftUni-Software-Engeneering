function oddOccurences(input) {
  const tokens = input.split(" ");

  const words = [];
  const oddWords = [];

  for (const element of tokens) {
    const word = {
      word: element.toLowerCase(),
      counter: 1,
    };

    const matchingWord = words.find((entry) => entry.word === word.word);

    if (matchingWord) {
      matchingWord.counter++;
    } else {
      words.push(word);
    }
  }

  for (const word of words) {
    if (word.counter % 2 === 1) {
      oddWords.push(word.word);
    }
  }

  console.log(oddWords.join(" "));
}

oddOccurences("Java C# Php PHP Java PhP 3 C# 3 1 5 C#");
oddOccurences("Cake IS SWEET is Soft CAKE sweet Food");
