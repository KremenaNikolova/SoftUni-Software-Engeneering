let names = {
  fName: "John",
  lName: "Doe",
  age: 22,
  getPersonInfo() {
    return `${this.fName} ${this.lName}, age ${this.age}`;
  },
};
let location = {
  city: "Boston",
  street: "Nowhere street",
  number: 13,
  postalCode: 51225,
  getAddressInfo() {
    return `${this.street} ${this.number}, ${this.city} ${this.postalCode}`;
  },
};

type Names = typeof names;
type Location = typeof location;
type Person = Names & Location;

function createCombineFunction(names: Names, location: Location) {
  return function (person: Person) {
    console.log(
      `Hello, ${person.getPersonInfo()} from ${person.getAddressInfo()}`
    );
  };
}

let combinedFunction = createCombineFunction(names, location);
let combinedPerson = Object.assign({}, names, location);
combinedFunction(combinedPerson);
