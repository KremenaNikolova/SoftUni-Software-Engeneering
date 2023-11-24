function occurrencesFinder(wordsArray) {
  const occurrencesWords = wordsArray[0].split(" ");
  const wordsCounter = [];

  for (const word of occurrencesWords) {
    const element = {
      word: word,
      counter: 0,
    };

    wordsCounter.push(element);
  }

  for (let i = 1; i < wordsArray.length; i++) {
    const currWord = wordsArray[i];

    const matchingWord = wordsCounter.find((entry) => entry.word === currWord);

    if (matchingWord) {
      matchingWord.counter++;
    }
  }

  wordsCounter.sort((a, b) => b.counter - a.counter);

  for (const word of wordsCounter) {
    console.log(`${word.word} - ${word.counter}`);
  }
}

occurrencesFinder([
  "this sentence",
  "In",
  "this",
  "sentence",
  "you",
  "have",
  "to",
  "count",
  "the",
  "occurrences",
  "of",
  "the",
  "words",
  "this",
  "and",
  "sentence",
  "because",
  "this",
  "is",
  "your",
  "task",
]);

occurrencesFinder([
  "is the",
  "first",
  "sentence",
  "Here",
  "is",
  "another",
  "the",
  "And",
  "finally",
  "the",
  "the",
  "sentence",
]);
