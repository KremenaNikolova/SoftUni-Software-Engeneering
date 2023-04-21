//Read a list of integers and print the largest 3 of them. If there are less than 3, print all of them.

using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_Largest_3_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> threeBigestNumbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            //threeBigestNumbers = threeBigestNumbers.OrderByDescending(x => x).ToList();

            Console.WriteLine(String.Join(" ",threeBigestNumbers.OrderByDescending(x=> x).Take(3)));
        }
    }
}
