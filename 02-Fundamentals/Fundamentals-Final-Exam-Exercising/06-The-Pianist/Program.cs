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


            Dictionary<string, List<int>> plants = new Dictionary<string, List<int>>();
            Dictionary<string, double> plantsRating = new Dictionary<string, double>();

            for (int i = 0; i < counter; i++)
            {
                string[] plantInformation = Console.ReadLine().Split("<->");
                string key = plantInformation[0];
                if (!plants.ContainsKey(key))
                {
                    plants.Add(key, new List<int> { int.Parse(plantInformation[1]), 0 });
                    plantsRating.Add(key, 0);
                }
                else
                {
                    plants[key] = new List<int> { int.Parse(plantInformation[1]) };
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
            foreach (var plant in plants)
            {
                foreach (var rating in plantsRating)
                {
                    if (plant.Key == rating.Key)
                    {
                        Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value[0]}; Rating: {(rating.Value / plant.Value[1]):f2}");
                        break;
                    }

                }
            }

        }

        private static void Rate(string plant, double rating, Dictionary<string, List<int>> plants, Dictionary<string, double> plantsRating)
        {
            plants[plant][1]++;
            plantsRating[plant] += rating;
        }

        private static void Update(string plant, int rarity, Dictionary<string, List<int>> plants, Dictionary<string, double> plantsRating)
        {
            plants[plant][0] = rarity;
        }

        private static void Reset(string plant, Dictionary<string, List<int>> plants, Dictionary<string, double> plantsRating)
        {
            plantsRating[plant] = 0;
        }
    }
}
