function calculate(fruit, weight, price) {
    let gramToKg = weight / 1000;
    let totalPrice = gramToKg * price;

    console.log(`I need $${totalPrice.toFixed(2)} to buy ${gramToKg.toFixed(2)} kilograms ${fruit}.`);
}

calculate('orange', 2500, 1.80);
calculate('apple', 1563, 2.35);