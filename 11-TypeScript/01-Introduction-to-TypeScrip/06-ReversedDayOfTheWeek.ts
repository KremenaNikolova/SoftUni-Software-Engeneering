function ConvertWeekToNumber(weekDay: string) {
  enum DaysOfTheWeek {
    Monday = 1,
    Tuseday = 2,
    Wednesday = 3,
    Thursday = 4,
    Friday = 5,
    Saturday = 6,
    Sunday = 7,
  }

  // const stringKeys = Object.keys(DaysOfTheWeek).filter((v) => isNaN(Number(v)));

  // let result: number | string = 0;
  // stringKeys.forEach((key, index) => {
  //   if (key === weekDay) result = index + 1;
  //   else if (result === 0) result = "error";
  // });

  let result = DaysOfTheWeek[weekDay as keyof typeof DaysOfTheWeek] || "error";
    
  return console.log(result);
}

ConvertWeekToNumber('Monday'); //1
ConvertWeekToNumber('Friday'); //5
ConvertWeekToNumber('Invalid'); //error
