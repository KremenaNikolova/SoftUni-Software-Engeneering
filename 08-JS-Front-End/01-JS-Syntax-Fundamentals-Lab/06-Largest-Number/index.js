function input(num1, num2, num3){
    let bigestNum = Number.MIN_SAFE_INTEGER;
    if(bigestNum<num1){
        bigestNum=num1;
    }
    if(bigestNum<num2){
        bigestNum=num2;
    }
    if(bigestNum<num3){
        bigestNum=num3;
    }

    console.log(`The largest number is ${bigestNum}.`);
}

input(5, -3, 16);
input(-3, -5, -22.5);