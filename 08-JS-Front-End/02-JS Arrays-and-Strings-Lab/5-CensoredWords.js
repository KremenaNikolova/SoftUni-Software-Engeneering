function censoring(sentence, word) {
  let censor = "*".repeat(word.length);

  while (sentence.includes(word)) {
    sentence = sentence.replace(word, censor);
  }

  console.log(sentence);
}

censoring("A small sentence with some words", "small");
censoring("Find the hidden word", "hidden");
