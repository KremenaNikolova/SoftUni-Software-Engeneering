function personInfo(args){
    let addressBook = {};

    for (let i = 0; i < args.length; i++) {
        let tokens = args[i].split(':');

        let name = tokens[0];
        let address = tokens[1];

        addressBook[name] = address;
        
    }

    // let sortedBook = Object.fromEntries(
    //     Object.entries(addressBook)
    //     .sort(function(a, b){
    //     if (a.name < b.name) {
    //         return -1;
    //     }
    //     if (a.name > b.name) {
    //         return 1;
    //     }
    //     return 0;
    // }));

    let sortedBook = Object.fromEntries(
        Object.entries(addressBook)
        .sort((a, b) => a[0].localeCompare(b[0]))
    );

    for (const key in sortedBook) {
        console.log(`${key} -> ${addressBook[key]}`);
    }
}


personInfo(
    ['Tim:Doe Crossing',
    'Bill:Nelson Place',
    'Peter:Carlyle Ave',
    'Bill:Ornery Rd']
);