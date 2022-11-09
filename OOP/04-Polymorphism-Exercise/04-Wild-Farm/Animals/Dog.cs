using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_Farm.Animals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, int foodEaten, string livingRegion) : base(name, weight, foodEaten, livingRegion)
        {}

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
