//Create a program that counts in a given array of double values the number of occurrences of each value. 

using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> counting = new Dictionary<double, int>();

            double[] input = Console.ReadLine().Split().Select(double.Parse).ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                if (!counting.ContainsKey(input[i]))
                {
                    counting.Add(input[i], 1);
                }
                else
                {
                    counting[input[i]]++;
                }
                
            }

            foreach (var number in counting)
            {
                Console.WriteLine($"{number.Key} - {number.Value} times");
            }
        }
    }
}
