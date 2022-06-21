using System;
using System.Collections.Generic;
using System.Linq;

namespace _5_Remove_Negatives_and_Reverse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();

            input.RemoveAll(input => input < 0);
            input.Reverse();
            if (input.Count==0)
            {
                Console.WriteLine("empty");
            }
            else
            {
                Console.WriteLine(String.Join(" ", input));
            }
        }
    }
}
