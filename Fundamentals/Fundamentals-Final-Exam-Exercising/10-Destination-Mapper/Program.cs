using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _10_Destination_Mapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string locationsInput = Console.ReadLine();
            string pattern = @"(=|/{1})([A-Z][A-Za-z]{2,})\1";
            List<string> locations = new List<string>();
            
            MatchCollection matches = Regex.Matches(locationsInput, pattern);
            int counter = 0;

            foreach (var match in matches)
            {
                string location = match.ToString();
                string validLocation = string.Empty;
                for (int i = 1; i < location.Length-1; i++)
                {
                    counter++;
                    validLocation += location[i];
                }
                locations.Add(validLocation);
            }

            Console.WriteLine($"Destinations: {string.Join(", ", locations)}");
            Console.WriteLine($"Travel Points: {counter}");
        }
    }
}
