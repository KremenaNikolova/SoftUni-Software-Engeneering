//You are given a lower and an upper bound for a range of integer numbers.
//Then a command specifies if you need to list all even or odd numbers in the given range. Use Predicate<T>.

using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            List<int> numbers = new List<int>();
            List<int> output = new List<int>();
            
            for (int i = input[0]; i <= input[1]; i++)
            {
                numbers.Add(i);
            }
            Predicate<int> evenNum = number => number % 2 == 0;
            Predicate<int> oddNum = number => number % 2 != 0;

            string command = Console.ReadLine();

            if (command=="even")
            {
                output = numbers.FindAll(evenNum);
            }
            else
            {
                output = numbers.FindAll(oddNum);
            }

            Console.WriteLine(string.Join(" ", output));
            

        }
    }
}
