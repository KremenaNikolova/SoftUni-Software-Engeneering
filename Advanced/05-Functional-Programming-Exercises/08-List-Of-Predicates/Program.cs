//Find all numbers in the range 1…N that are divisible by the numbers of a given sequence.
//On the first line, you will be given an integer N – which is the end of the range.
//On the second line, you will be given a sequence of integers which are the dividers.
//Use predicates/functions.

using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_List_Of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int endRange = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            List<int> list = new List<int>();
            
            for (int i = 1; i <= endRange; i++)
            {
                bool isDivisible = true;
                for (int j = 0; j < dividers.Length; j++)
                {
                    if (i % dividers[j]!=0)
                    {
                        isDivisible = false;
                    }
                }
                if (isDivisible)
                {
                    list.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", list));
        }
    }
}
