function personInfo(firstName, lastName, age){
    let person = {};
    person.firstName = firstName;
    person.lastName = lastName;
    person.age = age;

    return person;
}


console.log(personInfo(
    "Peter", 
    "Pan",
    "20"
    ));

console.log(personInfo(
    "George", 
    "Smith",
    "18"
     ));