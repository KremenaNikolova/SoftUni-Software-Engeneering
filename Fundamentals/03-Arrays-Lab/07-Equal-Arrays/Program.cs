using System;
using System.Linq;

namespace _07_Equal_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstLine = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] secondLine = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int summOfTheLines = 0;

            for (int i = 0; i < firstLine.Length; i++)
            {
                if (firstLine[i] == secondLine[i])
                {
                    summOfTheLines+=firstLine[i];
                }
                else
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    return;
                }
            }

            Console.WriteLine($"Arrays are identical. Sum: {summOfTheLines}");


        }
    }
}
