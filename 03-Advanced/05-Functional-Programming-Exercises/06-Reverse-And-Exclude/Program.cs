//Create a program that reverses a collection and removes elements that are divisible by a given integer n.
//Use predicates/functions.

using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_Reverse_And_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int devideNum = int.Parse(Console.ReadLine());
            List<int> avalibleNums = new List<int>();    

            Predicate<int> checkDeviding = num => num % devideNum == 0;
            Action<List<int>> reverse = nums => nums.Reverse();

           foreach (int num in input)
            {
                if (!checkDeviding(num))
                {
                    avalibleNums.Add(num);
                }
            }

           reverse(avalibleNums);

            Console.WriteLine(string.Join(" ", avalibleNums));

        }
    }
}
