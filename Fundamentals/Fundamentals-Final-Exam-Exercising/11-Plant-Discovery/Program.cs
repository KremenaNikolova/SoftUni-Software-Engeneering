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
            Dictionary<string, Plant> plantInformation = new Dictionary<string, Plant>();

            for (int i = 0; i < counter; i++)
            {
                string[] plantInfo = Console.ReadLine().Split("<->");

                string plant = plantInfo[0];
                int rarity = int.Parse(plantInfo[1]);
                Plant plantsinfo = new Plant(rarity, 0, 0);
                if (!plantInformation.ContainsKey(plant))
                {
                    plantInformation.Add(plant, plantsinfo);
                }
                else
                {
                    plantInformation[plant] = plantsinfo;
                }

            }

            string[] command = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);
            while (command[0] != "Exhibition")
            {
                string action = command[0];
                string[] tokens = command[1].Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                switch (action)
                {
                    case "Rate":
                        Rate(tokens[0].Trim(), double.Parse(tokens[1]), plantInformation);
                        break;
                    case "Update":
                        Update(tokens[0].Trim(), int.Parse(tokens[1]), plantInformation);
                        break;
                    case "Reset":
                        Reset(tokens[0].Trim(), plantInformation);
                        break;
                }


                command = Console.ReadLine().Split(":", StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine("Plants for the exhibition:");
            foreach (var plant in plantInformation)
            {
                if (plant.Value.Counter>0)
                {
                    double avarageRate = plant.Value.Rating / plant.Value.Counter;
                    Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value.Rarity}; Rating: {(avarageRate):f2}");
                }
                else
                {
                    Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value.Rarity}; Rating: 0.00");
                }
                
            }
        }

        private static void Rate(string plantName, double rating, Dictionary<string, Plant> plantInformation)
        {
            if (plantInformation.ContainsKey(plantName))
            {
                plantInformation[plantName].Rating += rating;
                plantInformation[plantName].Counter++;
            }
            else
            {
                Console.WriteLine("error");
            }
        }

        private static void Update(string plantName, int newRarity, Dictionary<string, Plant> plantInformation)
        {
            if (plantInformation.ContainsKey(plantName))
            {
                plantInformation[plantName].Rarity = newRarity;
            }
            else
            {
                Console.WriteLine("error");
            }
        }

        private static void Reset(string plantName, Dictionary<string, Plant> plantInformation)
        {
            if (plantInformation.ContainsKey(plantName))
            {
                plantInformation[plantName].Rating = 0;
                plantInformation[plantName].Counter = 0;
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }

    class Plant
    {
        public Plant(int rarity, double rating, int counter)
        {
            this.Rarity = rarity;
            this.Rating = rating;
            this.Counter = counter;
        }

        public int Rarity { get; set; }
        public double Rating { get; set; }
        public int Counter { get; set; }
    }
}

