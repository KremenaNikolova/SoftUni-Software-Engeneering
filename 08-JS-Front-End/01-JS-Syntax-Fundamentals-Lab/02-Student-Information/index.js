function info(name, age, avgGrade){
    let studentInfo = `Name: ${name}, Age: ${age}, Grade: ${avgGrade.toFixed(2)}`;

    console.log(studentInfo);
}

info('John', 15, 5.54678);
info('Steve', 16, 2.1426);
info('Marry', 12, 6.00);