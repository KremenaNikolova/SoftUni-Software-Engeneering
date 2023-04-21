//Create a program that executes some mathematical operations on a given collection.
//On the first line, you are given a list of numbers. On the next lines, you are passed different commands that you need to apply to all the numbers in the list:
///•	"add"->add 1 to each number
///•	"multiply" -> multiply each number by 2
///•	"subtract" -> subtract 1 from each number
///•	"print" -> print the collection
///•	"end" -> ends the input 


using System;
using System.Linq;

namespace _05_Applied_Arithmetics
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            string command = Console.ReadLine();

            Func<int[], int[]> add = nums => nums.Select(x => x + 1).ToArray();
            Func<int[], int[]> multiply = nums => nums.Select(x => x * 2).ToArray();
            Func<int[], int[]> subtract = nums => nums.Select(x => x - 1).ToArray();
            Action<int[]> print = nums => Console.WriteLine(string.Join(" ", input));

            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        input = add(input);
                        break;
                    case "subtract":
                        input = subtract(input);
                        break;
                    case "multiply":
                        input = multiply(input);
                        break;
                    case "print":
                        print(input);
                        break;
                }
                command = Console.ReadLine();
            }

        }


    }
}
