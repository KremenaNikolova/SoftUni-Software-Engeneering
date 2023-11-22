function appointmentsManges(appointments) {
  let meetings = {};

  for (const element of appointments) {
    let tokens = element.split(" ");
    let weekday = tokens[0];
    let name = tokens[1];

    if (!meetings.hasOwnProperty(weekday)) {
      meetings[weekday] = name;
      console.log(`Scheduled for ${weekday}`);
    } else {
      console.log(`Conflict on ${weekday}!`);
    }
  }

  for (const key in meetings) {
    console.log(`${key} -> ${meetings[key]}`);
  }
}

appointmentsManges([
  "Monday Peter",
  "Wednesday Bill",
  "Monday Tim",
  "Friday Tim",
]);

appointmentsManges([
  "Friday Bob",
  "Saturday Ted",
  "Monday Bill",
  "Monday John",
  "Wednesday George",
]);
