function adventure(input) {
  const countOfAstronauts = input.shift();
  const astronauts = {};

  for (let i = 0; i < countOfAstronauts; i++) {
    const currAstrounaut = input.shift();
    const [name, oxygenLevel, energyReserves] = currAstrounaut.split(" ");

    astronauts[name] = {
      oxygen: Number(oxygenLevel),
      energy: Number(energyReserves),
    };
  }

  let currCommandLine = input.shift();
  while (currCommandLine != "End") {
    let [command, name, amount] = currCommandLine.split(" - ");

    switch (command) {
      case "Explore":
        const energyNeeded = amount;
        if (energyNeeded <= astronauts[name].energy) {
          astronauts[name].energy -= energyNeeded;
          console.log(
            `${name} has successfully explored a new area and now has ${astronauts[name].energy} energy!`
          );
        } else {
          console.log(`${name} does not have enough energy to explore!`);
        }
        break;
      case "Refuel":
        astronauts[name].energy += Number(amount);
        if (astronauts[name].energy > 200) {
          let overage = astronauts[name].energy - 200;
          amount -= overage;
          astronauts[name].energy = 200;
        }
        console.log(`${name} refueled their energy by ${amount}!`);
        break;
      case "Breathe":
        astronauts[name].oxygen += Number(amount);
        if (astronauts[name].oxygen > 100) {
          let overage = astronauts[name].oxygen - 100;
          amount -= overage;
          astronauts[name].oxygen = 100;
        }
        console.log(`${name} took a breath and recovered ${amount} oxygen!`);
        break;
    }

    currCommandLine = input.shift();
  }

  for (const astronautName in astronauts) {
    console.log(
      `Astronaut: ${astronautName}, Oxygen: ${astronauts[astronautName].oxygen}, Energy: ${astronauts[astronautName].energy}`
    );
  }
}

adventure([
  "3",
  "John 50 120",
  "Kate 80 180",
  "Rob 70 150",
  "Explore - John - 50",
  "Refuel - Kate - 30",
  "Breathe - Rob - 20",
  "End",
]);

adventure([
  "4",
  "Alice 60 100",
  "Bob 40 80",
  "Charlie 70 150",
  "Dave 80 180",
  "Explore - Bob - 60",
  "Refuel - Alice - 30",
  "Breathe - Charlie - 50",
  "Refuel - Dave - 40",
  "Explore - Bob - 40",
  "Breathe - Charlie - 30",
  "Explore - Alice - 40",
  "End",
]);
