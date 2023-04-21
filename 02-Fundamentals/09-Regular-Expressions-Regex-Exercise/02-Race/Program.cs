using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02_Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Regex namesPattern = new Regex(@"(?<name>[A-Za-z]+)");
            string digitsPatter = @"(?<distance>[\d+])";

            Dictionary<string, int> winners = new Dictionary<string, int>();

            var participans = Console.ReadLine().Split(", ").ToList();
            string input = Console.ReadLine();

            while (input != "end of race")
            {
                MatchCollection names = namesPattern.Matches(input);
                MatchCollection digits = Regex.Matches(input, digitsPatter);

                string name = string.Join("", names);
                if (participans.Contains(name))
                {
                    int totalDistance = 0;
                    string distance = string.Join("", digits);

                    if (!winners.ContainsKey(name))
                    {
                        for (int i = 0; i < distance.Length ; i++)
                        {
                            totalDistance += int.Parse(distance[i].ToString());
                        }
                        winners.Add(name, totalDistance);
                    }
                    else
                    {
                        for (int i = 0; i < distance.Length; i++)
                        {
                            totalDistance += int.Parse(distance[i].ToString());
                        }
                        winners[name] += totalDistance;
                    }
                }

                input = Console.ReadLine();
            }

            var bestwinners = winners.OrderByDescending(x => x.Value).Take(3);
            List<string> list = new List<string>();

            foreach (var name in bestwinners)
            {
                list.Add(name.Key);
            }

            string firstPlayer = list[0];
            string secondPlayer = list[1];
            string thirthPLayer = list[2];

            Console.WriteLine($"1st place: {firstPlayer}");
            Console.WriteLine($"2nd place: {secondPlayer}");
            Console.WriteLine($"3rd place: {thirthPLayer}");




        }
    }
}
