function matrix(digit){
    for (let i = 0; i < digit; i++) {

        let array = new Array;

        for (let j = 0; j < digit; j++) {
            array.push(digit);
        }
        
        console.log(array.join(" "));
    }
}

matrix(3);

matrix(7);