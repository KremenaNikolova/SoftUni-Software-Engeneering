function PersonInfo(input: [name: string, age: number]) {
  return console.log(`Hello, my name is ${input[0]} and my age is ${input[1]}`);
}

//PersonInfo(['Ivan', 20]); // Hello, my name is Ivan and my age is 20
//PersonInfo(['Joro', 30]); // Hello, my name is Joro and my age is 30
//PersonInfo(["Ivan", 20, "Ivanov"]); // TS Error
//PersonInfo(['Joro', '25']); // TS Error
//PersonInfo([]);   // TS Error
