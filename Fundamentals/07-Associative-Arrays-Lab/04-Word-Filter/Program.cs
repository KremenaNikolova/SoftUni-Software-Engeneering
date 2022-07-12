using System;
using System.Collections.Generic;

namespace _04_Word_Filter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> evenLettersWords = new Dictionary<string, string>();

            string[] input = Console.ReadLine().Split();

            foreach (var item in input)
            {
                if (item.Length%2 == 0)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
