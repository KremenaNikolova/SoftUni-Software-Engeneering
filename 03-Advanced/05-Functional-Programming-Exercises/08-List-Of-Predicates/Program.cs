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
            Stack<int> divisibles = new Stack<int>();
            Action<Stack<int>> print = stack => Console.WriteLine(string.Join(" ", stack.Reverse()));

            for (int i = 1; i <= endRange; i++)
            {
                Predicate<int> isDivisible = x => i % x == 0;
                divisibles.Push(i);
                for (int j = 0; j < dividers.Length; j++)
                {
                    if (!isDivisible(dividers[j]))
                    {
                        divisibles.Pop();
                        break;
                    }
                }
            }

            print(divisibles);

        }


    }
}
