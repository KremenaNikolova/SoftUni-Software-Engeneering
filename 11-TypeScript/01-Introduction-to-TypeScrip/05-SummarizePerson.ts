function SummerizePerson(id: number, firstName: string, lastName: string, age: number, middleName?: string, hobbies?: string[], workInfo?: [string, number] ) :[number, string, number, string, string] {
    
    let fullName: string;
    if (middleName) {
        fullName = `${firstName} ${middleName} ${lastName}`;
    } else {
        fullName = `${firstName}  ${lastName}`;
    }

    let personHobbies: string;
    if (!hobbies) personHobbies = '-';
    else {
        personHobbies = hobbies.join(', ');
    }

    let workInformation: string;
    if (!workInfo) workInformation = '-';
    else {
        workInformation = `${workInfo[0]} -> ${workInfo[1]}`;
    }

    let result: [number, string, number, string, string] = [id, fullName, age, personHobbies, workInformation]
    return result;
}

console.log(SummerizePerson(12, 'Eliot', 'Des', 20, 'Braylen', ['tennis', 'football', 'hiking'], ['Sales Consultant', 2500]));
//output: [12, 'Eliot Braylen Des', 20, 'tennis, football, hiking', 'Sales Consultant -> 2500']

console.log(SummerizePerson(20, 'Mary', 'Trent', 25, undefined, ['fitness', 'rowing']));
//output: [20, 'Mary Trent', 25, 'fitness, rowing', '-']

console.log(SummerizePerson(21, 'Joseph', 'Angler', 28));
//output [21, 'Joseph Angler', 28, '-', '-']

console.log(SummerizePerson(21, 'Kristine', 'Neva', 23, ''));
//output [21, 'Kristine Neva', 23, '-', '-']