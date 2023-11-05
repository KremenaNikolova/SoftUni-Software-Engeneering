function solve(stringArray, step) {
  let currElement = "";
  let newAray = [];

  for (let i = 0; i < stringArray.length; i++) {
    if (i % step === 0) {
      currElement = stringArray[i].slice();
      newAray.push(currElement);
    }
  }

  return newAray;
}

solve(["5", "20", "31", "4", "20"], 2);
solve(["dsa", "asd", "test", "tset"], 2);
solve(["1", "2", "3", "4", "5"], 6);
