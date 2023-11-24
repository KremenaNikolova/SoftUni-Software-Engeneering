function carNumberSaver(input) {
  const parkingCars = [];

  for (let i = 0; i < input.length; i++) {
    const tokens = input[i].split(", ");
    const command = tokens[0];
    const carrNumber = tokens[1];
    if (command === "IN" && !parkingCars.includes(carrNumber)) {
      parkingCars.push(carrNumber);
    } else if (command === "OUT" && parkingCars.includes(carrNumber)) {
      const carrNumberIndex = parkingCars.findIndex((n) => n === carrNumber);

      parkingCars.splice(carrNumberIndex, 1);
    }
  }

  parkingCars.sort();

  if (parkingCars.length > 0) {
    console.log(parkingCars.join("\n"));
  } else {
    console.log("Parking Lot is Empty");
  }
}

carNumberSaver([
  "IN, CA2844AA",
  "IN, CA1234TA",
  "OUT, CA2844AA",
  "IN, CA9999TT",
  "IN, CA2866HI",
  "OUT, CA1234TA",
  "IN, CA2844AA",
  "OUT, CA2866HI",
  "IN, CA9876HH",
  "IN, CA2822UU",
]);

carNumberSaver([
  "IN, CA2844AA",
  "IN, CA1234TA",
  "OUT, CA2844AA",
  "OUT, CA1234TA",
]);
