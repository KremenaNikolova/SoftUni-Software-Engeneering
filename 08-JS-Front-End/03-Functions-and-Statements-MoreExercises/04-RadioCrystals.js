function currentThickness(input) {
    const desiredThickness = input.shift();

    for (let thickness of input) {
        console.log(`Processing chunk ${thickness} microns`)
        let currOpeartionCounter = 0;

        while (thickness > desiredThickness) {
            if (thickness / 4 >= desiredThickness) {
                thickness /= 4;
                currOpeartionCounter++;
            } else break;
        }

        console.log(`Cut x${currOpeartionCounter}`)
        currOpeartionCounter = 0;

        while (thickness > desiredThickness) {
            if (thickness * 0.8 >= desiredThickness) {
                thickness *= 0.8;
                currOpeartionCounter++;
            } else break;
        }

        console.log(`Lap x${currOpeartionCounter}`)
        currOpeartionCounter = 0;

        while (thickness > desiredThickness) {
            if (thickness -20 >= desiredThickness) {
                thickness -= 20;
                currOpeartionCounter++;
            } else break;
        }

        console.log(`Grind x${currOpeartionCounter}`)
        currOpeartionCounter = 0;

        while (thickness > desiredThickness) {
            if (thickness -2 > desiredThickness) {
                thickness -= 2;
                currOpeartionCounter++;
            } else break;
        }

        console.log(`Etch x${currOpeartionCounter}`)
        currOpeartionCounter = 0;

            if (thickness + 1< desiredThickness) {
                thickness += 1;
                currOpeartionCounter++;
            }
        console.log(`X-ray x${currOpeartionCounter}`)
    }


}

currentThickness([1375, 50000]);