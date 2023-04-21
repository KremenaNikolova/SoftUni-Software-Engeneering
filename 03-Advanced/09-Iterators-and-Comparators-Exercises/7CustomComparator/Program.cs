using System;
using System.Collections.Generic;
using System.Linq;

namespace _7CustomComparator
{
    public class Program
    {
        static void Main(string[] args)
        {
            //SortedSet<int> evenNumbers = new SortedSet<int>();
            //SortedSet<int> oddNumbers = new SortedSet<int>();
            //int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            //for (int i = 0; i < input.Length; i++)
            //{
            //    if (input[i] %2==0)
            //    {
            //        evenNumbers.Add(input[i]);
            //    }
            //    else
            //    {
            //        oddNumbers.Add(input[i]);
            //    }
            //}

            //foreach (var item in evenNumbers)
            //{
            //    Console.Write($"{item} ");
            //}

            //Console.WriteLine(string.Join(" ", oddNumbers));

            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Func<int, int, int> customComparator = (x, y) =>
            {
                if (x % 2 == 0 && y % 2 != 0)
                {
                    return -1;
                }
                if (x % 2 != 0 && y % 2 == 0)
                {
                    return 1;
                }
                return x.CompareTo(y);
            };

            Array.Sort(input, new Comparison<int>(customComparator));

            Console.WriteLine(string.Join(" ",input));
        }
    }
}
