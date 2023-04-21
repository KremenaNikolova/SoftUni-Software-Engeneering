using System;
using System.Collections.Generic;

namespace _03_Wild_Zoo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Animal> animals = new Dictionary<string, Animal>();
            Dictionary<string, int> areas = new Dictionary<string, int>();
            string[] command = Console.ReadLine().Split(":");

            while (command[0]!="EndDay")
            {
                string action = command[0];
                string[] token = command[1].Split("-");
                
                switch (action)
                {
                    case "Add":
                        Add(token[0], int.Parse(token[1]), token[2], animals, areas);
                        break;
                    case "Feed":
                        Feed(token[0], int.Parse(token[1]), animals, areas);
                        break;
                }

                command = Console.ReadLine().Split(":");
            }
            Console.WriteLine("Animals:");
            foreach (var animal in animals)
            {
                Console.WriteLine($" {animal.Key} -> {animal.Value.Quantity}g");
            }
            Console.WriteLine("Areas with hungry animals:");
            foreach (var area in areas)
            {
                Console.WriteLine($" {area.Key}: {area.Value}");
            }
        }

        private static void Feed(string name, int quantity, Dictionary<string, Animal> animals, Dictionary<string, int> areas)
        {
            if (animals.ContainsKey(name))
            {
                animals[name].Quantity -= quantity;
                if (animals[name].Quantity<=0)
                {
                    areas[animals[name].Area]--;
                    if (areas[animals[name].Area]<=0)
                    {
                        areas.Remove(animals[name].Area);
                    }
                    animals.Remove(name);
                    
                    Console.WriteLine($"{name} was successfully fed");
                }
            }
        }

        private static void Add(string name, int quantity, string area, Dictionary<string, Animal> animals, Dictionary<string, int> areas)
        {
            if (!areas.ContainsKey(area))
            {
                areas.Add(area, 1);
            }
            else if (areas.ContainsKey(area) && !animals.ContainsKey(name))
            {
                areas[area]++;
            }
            if (!animals.ContainsKey(name))
            {
                Animal animal = new Animal(quantity, area);
                animals.Add(name, animal);
            }
            else
            {
                animals[name].Quantity += quantity;
                animals[name].Area = area;
            }
            

            
        }
    }
    class Animal
    {
        public Animal(int quantity, string area)
        {
            this.Quantity = quantity;
            this.Area = area;
            //this.Counter = counter;
        }
        public int Quantity { get; set; }
        public string Area { get; set; }
        //public int Counter { get; set; }
    }
}
