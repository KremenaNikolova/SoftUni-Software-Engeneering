//Create a program that reads continents, countries and their cities put them in a nested dictionary and prints them.

using System;
using System.Collections.Generic;

namespace _05_Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> continentsInfo = new Dictionary<string, Dictionary<string, List<string>>>();
            int counter = int.Parse(Console.ReadLine());

            for (int i = 0; i < counter; i++)
            {
                string[] inputInformation = Console.ReadLine().Split();
                string continent = inputInformation[0];
                string country = inputInformation[1];
                string city = inputInformation[2];

                if (!continentsInfo.ContainsKey(continent))
                {
                    continentsInfo.Add(continent, new Dictionary<string, List<string>>());
                    continentsInfo[continent].Add(country, new List<string>());
                    continentsInfo[continent][country].Add(city);
                }
                else
                {
                    if (!continentsInfo[continent].ContainsKey(country))
                    {
                        continentsInfo[continent].Add(country, new List<string>());
                        continentsInfo[continent][country].Add(city);
                    }
                    else
                    {
                        continentsInfo[continent][country].Add(city);
                    }
                }
            }

            foreach (var continent in continentsInfo)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"{country.Key} -> {string.Join((", "), country.Value)}");
                }
            }
        }
    }
}
