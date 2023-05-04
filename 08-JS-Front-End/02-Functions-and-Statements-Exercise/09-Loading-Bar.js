function loadingBar(number){
    let loadingSymbol = '%';
    let loadingTimes = number / 10;

    let loading = '[..........]'

    for (let i = 0; i < loadingTimes; i++) {
        loading = loading.replace('.', loadingSymbol);
    }

    if (number === 100) {
        console.log(`100% Complete!`);
    } else {
        console.log(`${number}% ${loading}`);
        console.log(`Still loading...`);
    }
    
}

loadingBar(30);

loadingBar(50);

loadingBar(100);