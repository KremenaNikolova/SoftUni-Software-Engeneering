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
        static Func<int[], int[]> add =
                action => action.Select(x => ++x).ToArray();
        static Func<int[], int[]> subtract =
            action => action.Select(x => --x).ToArray();
        static Func<int[], int[]> multiply =
            action => action.Select(x => x * 2).ToArray();
        static Action<int[]> print =
            nums => Console.WriteLine(string.Join(" ", nums));
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x=>int.Parse(x)).ToArray();
            Result(Console.ReadLine(), input);
            
        }

        static void Result(string command, int[] input)
        {
            switch (command)
            {
                case "add":
                    input = add(input);
                    break;
                case "substract":
                    input = subtract(input);
                    break;
                case "multiply":
                    input = multiply(input);
                    break;
                case "print":
                    print(input);
                    break;
                case "end":
                    return;
            }
            Result(Console.ReadLine(), input);
        }


    }
}
