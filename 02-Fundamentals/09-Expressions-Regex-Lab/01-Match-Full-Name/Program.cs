using System;
using System.Text.RegularExpressions;

namespace _01_Match_Full_Name
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string regex = @"\b[A-Z]{1}[a-z]+[ ][A-Z]{1}[a-z]+";

            MatchCollection matches = Regex.Matches(input, regex);


            Console.WriteLine(string.Join(" ", matches));
        }
    }
}
