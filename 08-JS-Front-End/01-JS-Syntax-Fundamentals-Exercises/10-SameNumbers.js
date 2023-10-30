function numberCheck(digit) {
    let isSame = true;
    let compareDigit = digit % 10;
    let sum = 0;

    while (digit) {
        let currDigit = digit % 10;

        if (currDigit !== compareDigit) {
            isSame = false;
        }

        sum += currDigit;
        digit -= currDigit;
        digit /= 10;
  }

  console.log(isSame);
  console.log(sum);
}

numberCheck(2222222);
numberCheck(1234);
