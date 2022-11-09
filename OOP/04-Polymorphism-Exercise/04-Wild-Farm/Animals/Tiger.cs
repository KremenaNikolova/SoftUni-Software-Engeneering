using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_Farm.Animals
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, int foodEaten, string breed) : base(name, weight, foodEaten, breed)
        {}

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
