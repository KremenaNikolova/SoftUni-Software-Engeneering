function motoGP(input) {
  const numberOfRiders = input.shift();
  const riders = {};

  for (let i = 0; i < numberOfRiders; i++) {
    const [name, fuelCapacity, position] = input.shift().split("|");
    riders[name] = {
      fuel: Number(fuelCapacity),
      position,
    };
  }

  let commandLine = input.shift();
  while (commandLine != "Finish") {
    commandLine = commandLine.split(" - ");
    const command = commandLine.shift();

    switch (command) {
      case "StopForFuel":
        {
          const name = commandLine.shift();
          const minmumFuel = Number(commandLine.shift());
          const changePosition = commandLine.shift();
          if (riders[name].fuel >= minmumFuel) {
            console.log(`${name} does not need to stop for fuel!`);
          } else {
            riders[name].position = changePosition;
            console.log(
              `${name} stopped to refuel but lost his position, now he is ${changePosition}.`
            );
          }
        }
        break;
      case "Overtaking":
        {
          const rider1 = commandLine.shift();
          const rider2 = commandLine.shift();
          const rider1position = riders[rider1].position;
          const rider2position = riders[rider2].position;
          if (rider1position < rider2position) {
            riders[rider1].position = rider2position;
            riders[rider2].position = rider1position;

            console.log(`${rider1} overtook ${rider2}!`);
          }
        }
        break;
      case "EngineFail":
        {
          const name = commandLine.shift();
          const lapsLeft = commandLine.shift();
          delete riders[name];

          console.log(
            `${name} is out of the race because of a technical issue, ${lapsLeft} laps before the finish.`
          );
        }
        break;
    }

    commandLine = input.shift();
  }

  for (const rider in riders) {
    console.log(rider);
    console.log(`  Final position: ${riders[rider].position}`);
  }
}

motoGP([
  "3",
  "Valentino Rossi|100|1",
  "Marc Marquez|90|2",
  "Jorge Lorenzo|80|3",
  "StopForFuel - Valentino Rossi - 50 - 1",
  "Overtaking - Marc Marquez - Jorge Lorenzo",
  "EngineFail - Marc Marquez - 10",
  "Finish",
]);
