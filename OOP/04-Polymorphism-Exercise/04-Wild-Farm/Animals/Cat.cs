using System;
using System.Collections.Generic;
using System.Text;
using Wild_Farm.Food;

namespace Wild_Farm.Animals
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, int foodEaten, string breed) : base(name, weight, foodEaten, breed)
        {}

        public override void Feeding(Food food)
        {
            if (food == "")
            {

            }
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
