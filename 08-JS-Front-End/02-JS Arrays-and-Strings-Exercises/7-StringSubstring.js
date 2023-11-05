function solve(word, text) {
  let isWordExist = false;
  text.split(" ").map((t) => {
    if (t.toLowerCase() === word) {
      console.log(word);
      isWordExist = true;
    }
  });

  if (!isWordExist) {
    console.log(`${word} not found!`);
  }
}

solve("javascript", "JavaScript is the best programming language");
solve("python", "JavaScript is the best programming language");
