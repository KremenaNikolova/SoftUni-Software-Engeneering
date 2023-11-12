function numberModification(input) {
    while (getAvarage(input.toString()) < 5) {
        input += '9';
    }

    console.log(input);

    function getAvarage(number) {
        let result = 0;
        for (let i = 0; i < number.length; i++) {
            result += Number(number[i]);
        }
        result /= number.length;
        return result;
    }

}

numberModification(101);
numberModification(5853);