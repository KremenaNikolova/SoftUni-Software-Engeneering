function meetings(info){
    let appointments = {};
   
    for (let index = 0; index < info.length; index++) {
        let tokens = info[index].split(' ');

        let weekDay = tokens[0];
        let personName = tokens[1];

        if(!appointments.hasOwnProperty(weekDay)){
            appointments[weekDay] = personName;
            console.log(`Scheduled for ${weekDay}`);
        } else {
            console.log(`Conflict on ${weekDay}!`);
        }

    }

    for (const key in appointments) {
        console.log(`${key} -> ${appointments[key]}`);
    }
}

meetings(
['Monday Peter',
 'Wednesday Bill',
 'Monday Tim',
 'Friday Tim']
);