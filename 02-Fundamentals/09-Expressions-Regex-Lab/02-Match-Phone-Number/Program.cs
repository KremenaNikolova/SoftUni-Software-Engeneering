using System;
using System.Text.RegularExpressions;

namespace _02_Match_Phone_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"\+359(?<separator>[ -])[2](\k<separator>)[0-9]{3}(\k<separator>)[0-9]{4}\b";

            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);

            Console.WriteLine(string.Join(", ", matches));
        }
    }
}
