function employeeList(stringArr) {
  const employees = [];

  class Employee {
    constructor(name, personalNumber) {
      this.name = name;
      this.personalNumber = personalNumber;
    }
  }

  for (const employee of stringArr) {
    const persNumber = employee.length;
    employees.push(new Employee(employee, persNumber));

    console.log(`Name: ${employee} -- Personal Number: ${persNumber}`);
  }
}

employeeList([
  "Silas Butler",
  "Adnaan Buckley",
  "Juan Peterson",
  "Brendan Villarreal",
]);

employeeList(["Samuel Jackson", "Will Smith", "Bruce Willis", "Tom Holland"]);
