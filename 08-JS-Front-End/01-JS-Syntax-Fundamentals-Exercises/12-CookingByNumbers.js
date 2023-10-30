function cooking(...args) {
    let number = args[0];
    for (i = 1; i < args.length; i++){
        switch (args[i]) {
            case "chop":
                number /= 2; break;
            case "dice":
                number = Math.sqrt(number); break;
            case "spice":
                number += 1; break;
            case "bake":
                number *= 3; break;
            case "fillet":
                number -= number * 0.2; break;
        }

        console.log(number);
    }
}

cooking('32', 'chop', 'chop', 'chop', 'chop', 'chop');
cooking('9', 'dice', 'spice', 'chop', 'bake', 'fillet');