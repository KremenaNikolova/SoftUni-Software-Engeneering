//Create a simple program that reads from the console a set of integers and prints back on the console the smallest number from the collection.
//Use Func<T, T>.

using System;
using System.Linq;

namespace _03_Custom_Min_Function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> smallestNumber = (nums) =>
            {
                int smallestNumber = int.MaxValue;

                foreach (var num in nums)
                {
                    if (num<smallestNumber)
                    {
                        smallestNumber = num;
                    }
                }
                return smallestNumber;
            };
            int[] numbers = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Console.WriteLine(smallestNumber(numbers));

            

        }
    }
}
