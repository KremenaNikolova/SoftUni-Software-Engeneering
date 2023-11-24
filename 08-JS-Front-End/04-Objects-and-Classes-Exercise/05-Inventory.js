function heroesRegister(inputArray) {
  const heroes = [];

  for (const heroInfo of inputArray) {
    const tokens = heroInfo.split(" / ");

    const name = tokens[0];
    const level = tokens[1];
    const items = tokens[2];

    const hero = {
      name: name,
      level: Number(level),
      items: items,
    };

    heroes.push(hero);
  }

  heroes.sort((a, b) => a.level - b.level);

  for (const hero of heroes) {
    console.log(`Hero: ${hero.name}`);
    console.log(`level => ${hero.level}`);
    console.log(`items => ${hero.items}`);
  }
}

heroesRegister([
  "Isacc / 25 / Apple, GravityGun",
  "Derek / 12 / BarrelVest, DestructionSword",
  "Hes / 1 / Desolator, Sentinel, Antara",
]);

heroesRegister([
  "Batman / 2 / Banana, Gun",
  "Superman / 18 / Sword",
  "Poppy / 28 / Sentinel, Antara",
]);
