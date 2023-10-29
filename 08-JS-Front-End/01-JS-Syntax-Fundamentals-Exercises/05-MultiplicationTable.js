function multiplicationTable(num) {
  let count = 1;

  while (count <= 10) {
    let result = count * num;
    console.log(`${num} X ${count} = ${result}`);
    count++;
  }
}

multiplicationTable(5);
multiplicationTable(2);
