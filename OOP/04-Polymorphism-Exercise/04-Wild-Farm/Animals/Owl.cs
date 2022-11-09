using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_Farm.Animals
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, int foodEaten, double wingSize) : base(name, weight, foodEaten, wingSize)  {}

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
