using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Count_Chars_in_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> charCounts = new Dictionary<char, int>();

            string input = Console.ReadLine();
            string filtredInputRemovedSpaces = String.Concat(input.Where(w => !Char.IsWhiteSpace(w)));

            foreach (char charr in filtredInputRemovedSpaces)
            {
                if (!charCounts.ContainsKey(charr))
                {
                    charCounts.Add(charr, 0);
                }
                charCounts[charr]++;
            }

            foreach (var item in charCounts)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
