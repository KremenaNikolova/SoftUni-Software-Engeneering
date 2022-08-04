using System;
using System.Collections.Generic;
using System.Linq;

namespace _11_Plant_Discovery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());


            SortedDictionary<string, int> plants = new SortedDictionary<string, int>();
            SortedDictionary<string, List<double>> plantsRating = new SortedDictionary<string, List<double>>();

            for (int i = 0; i < counter; i++)
            {
                string[] plantInformation = Console.ReadLine().Split("<->");
                string key = plantInformation[0];
                int value = int.Parse(plantInformation[1]);
                if (!plants.ContainsKey(key))
                {
                    plants.Add(key, value);
                    plantsRating.Add(key, new List<double>{0, 0 });
                }
                else
                {
                    plants[key] = value;
                }
            }

            string[] command = Console.ReadLine().Split(new char[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "Exhibition")
            {
                string action = command[0];
                if (!plants.ContainsKey(command[1]))
                {
                    Console.WriteLine("error");
                    command = Console.ReadLine().Split(new char[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }
                switch (action)
                {
                    case "Rate:":
                        Rate(command[1], double.Parse(command[2]), plants, plantsRating);
                        break;
                    case "Update:":
                        Update(command[1], int.Parse(command[2]), plants, plantsRating);
                        break;
                    case "Reset:":
                        Reset(command[1], plants, plantsRating);
                        break;
                }

                command = Console.ReadLine().Split(new char[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine("Plants for the exhibition:");

            var sorted = plantsRating
                .OrderByDescending(x => x.Value[0])
                .ThenByDescending(x => plantsRating[x.Key].Count > 0
                    ? plantsRating[x.Key].Sum() / plantsRating[x.Key].Count
                    : 0.0);

            foreach (var rating in sorted)
            {
                foreach (var plant in plants)
                {
                    if (rating.Key==plant.Key)
                    {
                        Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value}; Rating: {rating.Value}");
                    }
                }
            }
        }

        private static void Rate(string plant, double rating, SortedDictionary<string, int> plants, SortedDictionary<string, List<double>> plantsRating)
        {

            plantsRating[plant][0] += rating;
            plantsRating[plant][1]++;
        }

        private static void Update(string plant, int rarity, SortedDictionary<string, int> plants, SortedDictionary<string, List<double>> plantsRating)
        {
            plants[plant] = rarity;
        }

        private static void Reset(string plant, SortedDictionary<string, int> plants, SortedDictionary<string, List<double>> plantsRating)
        {
            plantsRating[plant][0] = 0;
        }
    }
}
