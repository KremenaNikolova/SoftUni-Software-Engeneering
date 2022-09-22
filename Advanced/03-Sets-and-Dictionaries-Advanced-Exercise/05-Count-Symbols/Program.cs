//Create a program that reads some text from the console and counts the occurrences of each character in it. Print the results in alphabetical (lexicographical) order.

using System;
using System.Collections.Generic;

namespace _05_Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> countsSymbols = new SortedDictionary<char, int>();
            string input= Console.ReadLine();
            char[] inputToCharArray = input.ToCharArray();

            for (int i = 0; i < input.Length; i++)
            {
                if (!countsSymbols.ContainsKey(inputToCharArray[i]))
                {
                    countsSymbols.Add(inputToCharArray[i], 1);
                }
                else
                {
                    countsSymbols[inputToCharArray[i]]++;
                }
            }

            foreach (var symbol in countsSymbols)
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}
