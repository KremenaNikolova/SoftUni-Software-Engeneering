function solve(base, increment) {
  let steps = 0;
  let stones = 0;
  let marbles = 0;
  let lapises = 0;

  while (base > 2) {
    steps++;

    let perimeter = base * 4 - 4;
    let area = (base - 2) ** 2;

    if (steps % 5 === 0) {
      lapises += perimeter * increment;
    } else {
      marbles += perimeter * increment;
    }
    stones += area * increment;
    base -= 2;
  }
  steps++;
  const height = steps * increment;
  const golds = base ** 2 * increment;

  console.log(`Stone required: ${Math.ceil(stones)}`);
  console.log(`Marble required: ${Math.ceil(marbles)}`);
  console.log(`Lapis Lazuli required: ${Math.ceil(lapises)}`);
  console.log(`Gold required: ${Math.ceil(golds)}`);
  console.log(`Final pyramid height: ${Math.floor(height)}`);
}

solve(11, 1);
solve(11, 0.75);
solve(12, 1);
