function login(input) {
  const username = input.shift();
  const password = username.split("").reverse().join("");
  let elementsCounter = 0;

  for (const element of input) {
    elementsCounter++;
    if (elementsCounter === input.length && element !== password) {
      console.log(`User ${username} blocked!`);
    } else if (element !== password) {
      console.log("Incorrect password. Try again.");
    } else {
      console.log(`User ${username} logged in.`);
    }
  }
}

login(["Acer", "login", "go", "let me in", "recA"]);
login(["momo", "omom"]);
login(["sunny", "rainy", "cloudy", "sunny", "not sunny"]);
