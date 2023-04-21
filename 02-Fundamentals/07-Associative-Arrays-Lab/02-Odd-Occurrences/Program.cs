using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_Odd_Occurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> counts = new Dictionary<string, int>();

            string[] input = Console.ReadLine().Split().Select(input => input.ToLower()).ToArray();

            foreach (var item in input)
            {
                if (!counts.ContainsKey(item))
                {
                    counts.Add(item, 0);
                }
                counts[item]++;
            }

            string[] output = counts.Where(w => w.Value%2 != 0).Select(word => word.Key).ToArray();

            Console.WriteLine(string.Join(" ", output));



        }
    }
}
