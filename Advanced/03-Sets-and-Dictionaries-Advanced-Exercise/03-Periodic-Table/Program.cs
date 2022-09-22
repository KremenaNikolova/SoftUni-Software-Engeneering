//Create a program that keeps all the unique chemical elements. On the first line, you will be given a number n - the count of input lines that you are going to receive. On the next n lines, you will be receiving chemical compounds, separated by a single space. Your task is to print all the unique ones in ascending order:

using System;
using System.Collections.Generic;

namespace _03_Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> chemicalElements = new SortedSet<string>();
            int counter = int.Parse(Console.ReadLine());

            for (int i = 0; i < counter; i++)
            {
                string[] input = Console.ReadLine().Split();
                for (int j = 0; j < input.Length; j++)
                {
                    chemicalElements.Add(input[j]);
                }
            }

            foreach (var element in chemicalElements)
            {
                Console.Write(element + " ");
            }
        }
    }
}
