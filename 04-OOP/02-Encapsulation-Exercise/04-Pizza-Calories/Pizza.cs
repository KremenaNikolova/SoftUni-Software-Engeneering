using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace _04_Pizza_Calories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            Name = name;
            Dough = dough;

            toppings = new List<Topping>();
        }

        public string Name 
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length>15)
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }
        public Dough Dough { get; set; }
        public int Counter => toppings.Count;

        public void AddTopping(Topping topping)
        {
            if (Counter>10)
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }
            toppings.Add(topping);
        }

        public double TotalCalories => Dough.DoughCalories + toppings.Select(t=>t.ToppingCalories).Sum();

        public override string ToString()
        {
            return $"{Name} - {TotalCalories:f2} Calories.";
        }

    }
}
