using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_Farm.Animals
{
    public abstract class Feline : Animal
    {
        protected Feline(string name, double weight, int foodEaten, string breed) : base(name, weight, foodEaten)
        {
            Breed = breed;
        }

        public string Breed { get; set; }
    }
}
