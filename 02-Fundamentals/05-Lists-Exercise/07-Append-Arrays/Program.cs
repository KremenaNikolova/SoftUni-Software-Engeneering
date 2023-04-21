using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_Append_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<int> input = Console.ReadLine().Split('|').Select(int.Parse).ToList();

            List<string> input = Console.ReadLine().Split('|').Reverse().ToList();

            List<int> numbers = new List<int>();

            foreach (var number in input)
            {
                numbers.AddRange(number.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
