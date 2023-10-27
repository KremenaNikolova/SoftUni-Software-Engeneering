function determines(age) {
  let result;

  if (age >= 0 && age <= 2) {
    result = "baby";
  } else if (age > 2 && age <= 13) {
    result = "child";
  } else if (age > 13 && age <= 19) {
    result = "teenager";
  } else if (age > 19 && age <= 65) {
    result = "adult";
  } else if (age >= 66) {
    result = "elder";
  } else {
    result = "out of bounds";
  }

  console.log(result);
}

determines(20);
determines(1);
determines(100);
determines(-1);
