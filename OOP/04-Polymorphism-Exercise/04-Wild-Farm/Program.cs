using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Wild_Farm.Animals;
using Wild_Farm.Foods;

namespace Wild_Farm
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            string cmd;
            int counter = 0;
            Animal animal = null;
            while ((cmd = Console.ReadLine()) != "End")
            {
                if (counter % 2 == 0)
                {
                    animal = Factory.GetAnimals(cmd);
                    Console.WriteLine(animal.ProduceSound());
                    animals.Add(animal);
                }
                else if (counter % 2 != 0)
                {
                    Food food = Factory.GetFoods(cmd);
                    animal.Feeding(food);
                }
                
                counter++;

            }

            foreach (var anm in animals)
            {
                Console.WriteLine(anm);
            }
        }
    }
}
