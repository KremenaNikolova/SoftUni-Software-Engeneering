//Create a program that reads a line of integers separated by ", ". Print on two lines the count of numbers and their sum.

using System;
using System.Linq;

namespace _02_Sum_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            Console.WriteLine(input.Count());
            Console.WriteLine(input.Sum());
        }
    }
}
