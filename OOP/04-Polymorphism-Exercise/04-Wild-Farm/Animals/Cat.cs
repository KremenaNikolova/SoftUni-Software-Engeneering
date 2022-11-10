using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Wild_Farm.Foods;

namespace Wild_Farm.Animals
{
    public class Cat : Feline
    {
        public Cat(string name, double weight,string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {}

        public override double WeightGain => 0.3;

        public override void Feeding(Food food)
        {
            if (food == null)
            {
                return;
            }
            else if (food.GetType().Name == "Vegetable" || food.GetType().Name == "Meat")
            {
                this.Weight+= WeightGain * food.Quantity;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!"); 
            }
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
