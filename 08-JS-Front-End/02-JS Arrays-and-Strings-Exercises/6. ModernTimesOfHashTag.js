function solve(string) {
  const regex = /\B(\#[a-zA-Z]+\b)/g;

  let matches = string.match(regex);

  for (const word of matches) {
    console.log(word.replace("#", ""));
  }
}

solve("Nowadays everyone uses # to tag a #special word in #socialMedia");
