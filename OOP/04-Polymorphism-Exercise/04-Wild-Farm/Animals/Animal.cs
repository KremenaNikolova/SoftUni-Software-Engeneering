using System;
using System.Collections.Generic;
using System.Text;
using Wild_Farm.Foods;

namespace Wild_Farm.Animals
{
    public abstract class Animal
    {
        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
            FoodEaten = 0;
        }

        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }

        public abstract double WeightGain{ get; }

        public abstract string ProduceSound();
        public abstract void Feeding(Food food);

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, "; 
        }

    }
}
