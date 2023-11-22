function phoneBook(inputArray) {
    let book = {};
    
    for (const element of inputArray) {
        let personInfo = element.split(' ');
        let name = personInfo[0];
        let phoneNumber = personInfo[1];

        book[name] = phoneNumber;
    }

    for (const key in book) {
        console.log(`${key} -> ${book[key]}`);
    }
}

phoneBook(['Tim 0834212554',
    'Peter 0877547887',
    'Bill 0896543112',
    'Tim 0876566344']
);
phoneBook(['George 0552554',
    'Peter 087587',
    'George 0453112',
    'Bill 0845344']
);