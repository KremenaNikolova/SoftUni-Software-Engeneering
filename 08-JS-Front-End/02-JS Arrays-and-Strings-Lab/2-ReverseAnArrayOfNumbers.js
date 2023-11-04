function reverse(count, numArray) {
    let result = numArray.splice(0, count).reverse();

  console.log(result.join(" "));
}

reverse(3, [10, 20, 30, 40, 50]);
reverse(4, [-1, 20, 99, 5]);
reverse(2, [66, 43, 75, 89, 47]);
