function sum(num) { 
    let result = 0;
    let digit;

    while (num) {
        digit = num % 10;
        result += digit;
        num = Math.floor(num / 10);
    }

    console.log(result);
}

sum(245678);
sum(97561);
sum(543);