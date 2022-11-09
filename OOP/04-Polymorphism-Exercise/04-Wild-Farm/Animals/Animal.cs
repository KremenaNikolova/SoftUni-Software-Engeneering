using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_Farm.Animals
{
    public abstract class Animal
    {
        protected Animal(string name, double weight, int foodEaten)
        {
            Name = name;
            Weight = weight;
            FoodEaten = foodEaten;
        }

        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }

        public abstract string ProduceSound();
        public abstract void Feeding(Food food);

    }
}
