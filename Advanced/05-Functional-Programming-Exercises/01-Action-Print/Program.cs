//Create a program that reads a collection of strings from the console and then prints them onto the console.
//Each name should be printed on a new line.Use Action<T>.

using System;

namespace _01_Action_Print
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> print = name => Console.WriteLine(string.Join(Environment.NewLine, name));

            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            print(input);
        }
    }
}
