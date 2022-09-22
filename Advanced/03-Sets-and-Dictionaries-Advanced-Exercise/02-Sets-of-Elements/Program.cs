//Create a program that prints a set of elements. On the first line, you will receive two numbers - n and m, which represent the lengths of two separate sets. On the next n + m lines, you will receive n numbers, which are the numbers in the first set, and m numbers, which are in the second set. Find all the unique elements that appear in both of them and print them in the order in which they appear in the first set - n.

using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            int[] setsSize = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int firstSetSize = setsSize[0];
            int secondSetSize = setsSize[1];

            for (int i = 0; i < firstSetSize; i++)
            {
                int num= int.Parse(Console.ReadLine());
                firstSet.Add(num);
            }
            for (int i = 0; i < secondSetSize; i++)
            {
                int num = int.Parse(Console.ReadLine());
                secondSet.Add(num);
            }


            foreach (var number in firstSet)
            {
                foreach (var item in secondSet)
                {
                    if (number==item)
                    {
                        Console.Write(number + " ");
                    }
                }
            }

        }
    }
}
