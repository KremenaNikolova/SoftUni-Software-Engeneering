function printObject(stringArray) {
  for (const townInfo of stringArray) {
    const info = townInfo.split(" | ");
    const town = info[0];
    const latitude = Number.parseFloat(info[1]).toFixed(2);
    const longitude = Number.parseFloat(info[2]).toFixed(2);

    let townInformation = {
      town,
      latitude,
      longitude,
    };

    console.log(townInformation);
  }
}

printObject([
  "Sofia | 42.696552 | 23.32601",
  "Beijing | 39.913818 | 116.363625",
]);

printObject(["Plovdiv | 136.45 | 812.575"]);
