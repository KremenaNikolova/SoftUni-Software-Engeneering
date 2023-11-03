function wordsUppercase(string) {
  let words = [];
  let currentWord = "";

  for (let i = 0; i < string.length; i++) {
    let symbol = string[i];
    if (/^[a-zA-Z0-9_]$/.test(symbol)) {
      currentWord += symbol;
    } else if (currentWord.length > 0) {
      words.push(currentWord.toUpperCase());
      currentWord = "";
    }
  }

  if (currentWord.length > 0) {
    words.push(currentWord.toUpperCase());
  }

  let result = words.join(", ");
  console.log(result);
}

wordsUppercase("Hi, how are you?");
wordsUppercase("hello");
