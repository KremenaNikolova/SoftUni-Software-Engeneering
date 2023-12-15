function horseRacing(input) {
  const names = input.shift().split("|");
  const horses = Array.from(names);

  let cuurInputLine = input.shift();
  while (cuurInputLine != "Finish") {
    cuurInputLine = cuurInputLine.split(" ");
    const command = cuurInputLine.shift();

    switch (command) {
      case "Retake":
        {
          const firstHorse = cuurInputLine.shift();
          const secondHorse = cuurInputLine.shift();

          const firstHorsePosition = horses.indexOf(firstHorse);
          const secondHorsePosition = horses.indexOf(secondHorse);

          if (firstHorsePosition < secondHorsePosition) {
            swap(firstHorsePosition, secondHorsePosition);

            console.log(`${firstHorse} retakes ${secondHorse}.`);
          }
        }
        break;
      case "Trouble":
        {
          const horseName = cuurInputLine.shift();
          const horsePosition = horses.indexOf(horseName);
          if (horsePosition > 0) {
            swap(horsePosition, horsePosition - 1);
            console.log(`Trouble for ${horseName} - drops one position.`);
          }
        }
        break;
      case "Rage":
        {
          const horseName = cuurInputLine.shift();
          let horsePosition = horses.indexOf(horseName);
          const horseLastIndex = horses.length - 1;
          for (let i = 0; i < 2; i++) {
            if (horsePosition < horseLastIndex) {
              swap(horsePosition, horsePosition + 1);
              horsePosition++;
            }
          }
          console.log(`${horseName} rages 2 positions ahead.`);
        }
        break;
      case "Miracle":
        {
          const lastHorse = horses.shift();
          horses.push(lastHorse);
          console.log(`What a miracle - ${lastHorse} becomes first.`);
        }
        break;
    }
    cuurInputLine = input.shift();
  }

  console.log(horses.join("->"));
  const winner = horses.pop();
  console.log(`The winner is: ${winner}`);

  function swap(index1, index2) {
    const swap = horses[index1];
    horses[index1] = horses[index2];
    horses[index2] = swap;
  }
}

horseRacing([
  "Bella|Alexia|Sugar",
  "Retake Alexia Sugar",
  "Rage Bella",
  "Trouble Bella",
  "Finish",
]);

horseRacing([
  "Onyx|Domino|Sugar|Fiona",
  "Trouble Onyx",
  "Retake Onyx Sugar",
  "Rage Domino",
  "Miracle",
  "Finish",
]);

horseRacing([
  "Fancy|Lilly",
  "Retake Lilly Fancy",
  "Trouble Lilly",
  "Trouble Lilly",
  "Finish",
  "Rage Lilly",
]);
