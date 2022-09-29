//Create a program that reads one line of integers separated by ", ". Then prints the even numbers of that sequence sorted in increasing order.

using System;
using System.Linq;

namespace _01_Sort_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ", (Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(x => x % 2 == 0)
                .OrderBy(x => x)
                .ToList())));
        }
    }
}
