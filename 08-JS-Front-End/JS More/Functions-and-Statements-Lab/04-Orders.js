function totalPrice(product, quantity){
    let result = 0;
    switch(product){
        case "coffee": result = quantity * 1.5; break;
        case "water": result = quantity * 1; break;
        case "coke": result = quantity * 1.4; break;
        case "snacks": result = quantity * 2; break;
    }

    console.log(result.toFixed(2));
}

totalPrice("water", 5);
totalPrice("coffee", 2);