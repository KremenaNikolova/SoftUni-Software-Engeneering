
type digit = string | number;

function Multiplier(num1?: digit, num2?: digit, num3?: digit) {
  let numsArray = [num1, num2, num3];

  let result: number = 1;

  numsArray.forEach((num) => {
      if (num && typeof num === "string") {
          result *= parseInt(num);
      } else if(typeof num == 'number'){
          result *= num
      }
      
  });
    
    return numsArray.length > 0 ? result : 1;
}


console.log(Multiplier('3', 5, '10'));
console.log(Multiplier('2','2'));
console.log(Multiplier('2','2'));
console.log(Multiplier(undefined, 2, 3));
console.log(Multiplier(7, undefined, '2'));
console.log(Multiplier());

