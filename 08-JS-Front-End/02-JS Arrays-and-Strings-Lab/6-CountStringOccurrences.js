function wordCounter(sentence, word) {
  const array = sentence.split(' ');
  let counter = 0;

  for (const element of array) {
    if (element === word) {
      counter++;
    }
  }

  console.log(counter);
}

wordCounter("This is a word and it also is a sentence", "is");
wordCounter(
  "softuni is great place for learning new programming languages", "softuni");
