function convertJSON(name, lastName, hairColor) {
    const person = { name, lastName, hairColor };

    let personConvert = JSON.stringify(person);
    console.log(personConvert);
}

convertJSON('George', 'Jones', 'Brown');
convertJSON('Peter', 'Smith', 'Blond');