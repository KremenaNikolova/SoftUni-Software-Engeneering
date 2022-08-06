using System;
using System.Collections.Generic;

namespace _17_P_rates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] information = Console.ReadLine().Split("||", StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, Crew> crewInfo = new Dictionary<string, Crew>();

            while (information[0]!= "Sail")
            {
                string town = information[0];
                int population = int.Parse(information[1]);
                int gold = int.Parse(information[2]);
                if (!crewInfo.ContainsKey(town))
                {
                    Crew crew = new Crew(population, gold);
                    crewInfo.Add(town, crew);
                }
                else
                {
                    crewInfo[town].Poulation += population;
                    crewInfo[town].Gold += gold;
                }
                
                information = Console.ReadLine().Split("||", StringSplitOptions.RemoveEmptyEntries);
            }

            string[] command = Console.ReadLine().Split("=>", StringSplitOptions.RemoveEmptyEntries);
            while (command[0]!="End")
            {
                string action = command[0];

                switch (action)
                {
                    case "Plunder":
                        Plunder(command[1], int.Parse(command[2]), int.Parse(command[3]), crewInfo);
                        break;
                    case "Prosper":
                        Prosper(command[1], int.Parse(command[2]), crewInfo);
                        break;
                }

                command = Console.ReadLine().Split("=>", StringSplitOptions.RemoveEmptyEntries);
            }
            
            if (crewInfo.Count>0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {crewInfo.Count} wealthy settlements to go to:");
                foreach (var crew in crewInfo)
                {
                    Console.WriteLine($"{crew.Key} -> Population: {crew.Value.Poulation} citizens, Gold: {crew.Value.Gold} kg");
                }
                return;
            }
            Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");

            

        }

        private static void Plunder(string town, int people, int gold, Dictionary<string, Crew> crewInfo)
        {
            Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");
            crewInfo[town].Gold -= gold;
            crewInfo[town].Poulation -= people;
            if (crewInfo[town].Gold<=0 || crewInfo[town].Poulation<=0)
            {
                crewInfo.Remove(town);
                Console.WriteLine($"{town} has been wiped off the map!");
            }
        }

        private static void Prosper(string town, int gold, Dictionary<string, Crew> crewInfo)
        {
            if (gold<0)
            {
                Console.WriteLine("Gold added cannot be a negative number!");
                return;
            }
            crewInfo[town].Gold += gold;
            Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {crewInfo[town].Gold} gold.");
        }

        public class Crew
        {
            public Crew(int population, int gold)
            {
                this.Poulation = population;
                this.Gold = gold;
            }
            public int Poulation { get; set; }
            public int Gold { get; set; }
        }
    }
}
