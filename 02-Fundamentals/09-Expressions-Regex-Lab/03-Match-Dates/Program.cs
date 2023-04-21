using System;
using System.Text.RegularExpressions;

namespace _03_Match_Dates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string regex = @"(?<day>[0-9]{2})(?<separator>[\.\-\/])(?<month>[A-Z]{1}[a-z]{2})(\k<separator>)(?<year>[0-9]{4})";

            MatchCollection matches = Regex.Matches(input, regex);

            foreach (Match match in matches)
            {
                Console.WriteLine($"Day: {match.Groups["day"].Value}, Month: {match.Groups["month"].Value}, Year: {match.Groups["year"].Value}");
            }
        }
    }
}
