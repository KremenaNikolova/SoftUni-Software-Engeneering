function sum(array) {
  const firstElement = array[0];
  const lastElement = array[array.length - 1];

  const result = firstElement + lastElement;
  console.log(result);
}

sum([20, 30, 40]);
sum([10, 17, 22, 33]);
sum([11, 58, 69]);
