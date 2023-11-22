function convertObject(JSONinput) {
  let object = JSON.parse(JSONinput);

  let entries = Object.entries(object);
  for (const [key, value] of entries) {
    console.log(`${key}: ${value}`);
  }
}

convertObject('{"name": "George", "age": 40, "town": "Sofia"}');
convertObject('{"name": "Peter", "age": 35, "town": "Plovdiv"}');
