function input(arg){
    let result;
    if (typeof(arg) === 'number') {
        result = Math.pow(arg, 2) * Math.PI;
        return console.log(result.toFixed(2));
    }

    console.log(`We can not calculate the circle area, because we receive a ${typeof(arg)}.`)

}

input(5);
input('name');