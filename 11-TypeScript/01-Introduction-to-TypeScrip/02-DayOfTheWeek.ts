// function WeekDay(num: number): string {
    
//     let weekDay: string[] = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"];
    
//     if (num === 1) return weekDay[0]!;
//     else if (num === 2) return weekDay[1]!;
//     else if (num === 3) return weekDay[2]!;
//     else if (num === 4) return weekDay[3]!;
//     else if (num === 5) return weekDay[4]!;
//     else if (num === 6) return weekDay[5]!;
//     else if (num === 7) return weekDay[6]!;

//     return "error";
// }

// console.log(WeekDay(1)); //Monday
// console.log(WeekDay(5)); //Friday
// console.log(WeekDay(-1)); //error

function WeekDay(num: number): string {
    enum DaysOfTheWeek {
        Monday,
        Tuseday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    let result: string = DaysOfTheWeek[num-1] ?? "error";
    return result;
}

console.log(WeekDay(1)); //Monda
console.log(WeekDay(5)); //Friday
console.log(WeekDay(-1)); //error