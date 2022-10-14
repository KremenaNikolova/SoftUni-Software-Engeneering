using System;
using System.Collections.Generic;
using System.Linq;

namespace _4Froggy
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            Lake jumps = new Lake(input);

            Console.WriteLine(string.Join(", ",jumps));


        }
    }
}
