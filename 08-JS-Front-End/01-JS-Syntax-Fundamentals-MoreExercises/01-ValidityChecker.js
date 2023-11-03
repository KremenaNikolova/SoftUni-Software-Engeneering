function solve(x1, y1, x2, y2) {
    
    function checker(x1, y1, x2, y2) {
        let distance = Math.sqrt(Math.pow(x2 - x1, 2) + Math.pow(y2 - y1, 2));
        let status = "invalid";
        if (Number.isInteger(distance)) {
            status = "valid";
        }
    
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is ${status}`);
    }    

    checker(x1, y1, 0, 0);
    checker(x2, y2, 0, 0);
    checker(x1, y1, x2, y2);
}