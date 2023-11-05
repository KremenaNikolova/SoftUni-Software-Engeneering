function reveal(words, sentance) {
  let wordsArr = words.split(", ");

  for (const word of wordsArr) {
    let censored = "*".repeat(word.length);
    sentance = sentance.replace(censored, word);
  }

  console.log(sentance);
}

reveal(
  "great",
  "softuni is ***** place for learning new programming languages"
);

reveal(
  "great, learning",
  "softuni is ***** place for ******** new programming languages"
);
