//Create a program that reads a collection of names as strings from the console, appends "Sir" in front of every name
//and prints it back in the console. Use Action<T>.

using System;

namespace _02_Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> printer = names =>
            {
                foreach (var name in names)
                {
                    Console.WriteLine($"Sir {name}");
                }
            };
            

            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            printer(input);
        }
    }
}
