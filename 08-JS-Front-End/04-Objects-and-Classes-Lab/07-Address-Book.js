function sortAddressBook(personInfo) {
  let addressBook = {};

  for (const element of personInfo) {
    let [name, address] = element.split(":");

    addressBook[name] = address;
  }

  addressBook = Object.fromEntries(
    Object.entries(addressBook).sort((a, b) => a[0].localeCompare(b[0]))
  );

  for (const person in addressBook) {
    console.log(`${person} -> ${addressBook[person]}`);
  }
}

sortAddressBook([
  "Tim:Doe Crossing",
  "Bill:Nelson Place",
  "Peter:Carlyle Ave",
  "Bill:Ornery Rd",
]);

sortAddressBook([
  "Bob:Huxley Rd",
  "John:Milwaukee Crossing",
  "Peter:Fordem Ave",
  "Bob:Redwing Ave",
  "George:Mesta Crossing",
  "Ted:Gateway Way",
  "Bill:Gateway Way",
  "John:Grover Rd",
  "Peter:Huxley Rd",
  "Jeff:Gateway Way",
  "Jeff:Huxley Rd",
]);
