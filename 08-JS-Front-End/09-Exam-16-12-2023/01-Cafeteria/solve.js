function cafeteria(input) {
  const numberOfBaristast = input.shift();
  const baristas = {};

  for (let i = 0; i < numberOfBaristast; i++) {
    const currBarista = input.shift();

    const [name, shift, drinks] = currBarista.split(" ");

    baristas[name] = {
      shift,
      drinks: drinks.split(","),
    };
  }

  let commandLine = input.shift();
  while (commandLine !== "Closed") {
    commandLine = commandLine.split(" / ");

    const command = commandLine.shift();
    const name = commandLine.shift();

    switch (command) {
      case "Prepare":
        {
          const shift = commandLine.shift();
          const coffeeType = commandLine.shift();
          const isAvailibleCoffeeType =
            baristas[name].drinks.indexOf(coffeeType) > -1;

          if (baristas[name].shift === shift && isAvailibleCoffeeType) {
            console.log(`${name} has prepared a ${coffeeType} for you!`);
          } else {
            console.log(`${name} is not available to prepare a ${coffeeType}.`);
          }
        }
        break;
      case "Change Shift":
        {
          const newShift = commandLine.shift();
          baristas[name].shift = newShift;

          console.log(`${name} has updated his shift to: ${newShift}`);
        }
        break;
      case "Learn":
        {
          const newCoffeeType = commandLine.shift();
          const isExistingCoffeeType =
            baristas[name].drinks.indexOf(newCoffeeType) > -1;
          if (isExistingCoffeeType) {
            console.log(`${name} knows how to make ${newCoffeeType}.`);
          } else {
            baristas[name].drinks.push(newCoffeeType);
            console.log(
              `${name} has learned a new coffee type: ${newCoffeeType}.`
            );
          }
        }
        break;
    }

    commandLine = input.shift();
  }

  for (const name in baristas) {
    console.log(
      `Barista: ${name}, Shift: ${baristas[name].shift}, Drinks: ${baristas[
        name
      ].drinks.join(", ")}`
    );
  }
}

cafeteria([
  "3",
  "Alice day Espresso,Cappuccino",
  "Bob night Latte,Mocha",
  "Carol day Americano,Mocha",
  "Prepare / Alice / day / Espresso",
  "Change Shift / Bob / night",
  "Learn / Carol / Latte",
  "Learn / Bob / Latte",
  "Prepare / Bob / night / Latte",
  "Closed",
]);

cafeteria([
  "4",
  "Alice day Espresso,Cappuccino",
  "Bob night Latte,Mocha",
  "Carol day Americano,Mocha",
  "David night Espresso",
  "Prepare / Alice / day / Espresso",
  "Change Shift / Bob / day",
  "Learn / Carol / Latte",
  "Prepare / Bob / night / Latte",
  "Learn / David / Cappuccino",
  "Prepare / Carol / day / Cappuccino",
  "Change Shift / Alice / night",
  "Learn / Bob / Mocha",
  "Prepare / David / night / Espresso",
  "Closed",
]);
