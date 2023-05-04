function json(jsonString){
    let info = JSON.parse(jsonString);

    let entries = Object.entries(info);
    for (const [ key, value] of entries) {
        console.log(`${key}: ${value}`);
    }
}

json(
    '{"name": "George", "age": 40, "town": "Sofia"}'
);

json(
    '{"name": "Peter", "age": 35, "town": "Plovdiv"}'
);