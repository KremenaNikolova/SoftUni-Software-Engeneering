function convertJSON(firstName, lastName, hairColor){
    let jsonStr = {
        "name": firstName,
        "lastName": lastName,
        "hairColor": hairColor
    };

    let converted = JSON.stringify(jsonStr);
    console.log(converted);
}

convertJSON(
    'George', 'Jones', 'Brown'
)