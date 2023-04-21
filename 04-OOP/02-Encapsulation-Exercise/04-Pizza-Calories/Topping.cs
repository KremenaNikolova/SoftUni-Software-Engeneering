using System;
using System.Collections.Generic;
using System.Text;

namespace _04_Pizza_Calories
{
    public class Topping
    {
        private Dictionary<string, double> toppingInformation = new Dictionary<string, double>
        {
            {"meat", 1.2 },
            {"veggies", 0.8 },
            {"cheese", 1.1 },
            {"sauce", 0.9 },
        };

        private string toppingType;
        private double toppingWeight;

        public Topping(string toppingType, double toppingWeight)
        {
            ToppingType = toppingType;
            ToppingWeight = toppingWeight;
        }

        //formula: weight*2*toppingType

        public string ToppingType 
        {
            get { return toppingType; }
            private set
            {
                if (!toppingInformation.ContainsKey(value.ToLower()))
                {
                    throw new Exception($"Cannot place {value} on top of your pizza.");
                }
                toppingType=value;
            }
        }
        public double ToppingWeight 
        {
            get { return toppingWeight; }
            private set
            {
                if (value<1 || value>50)
                {
                    throw new Exception($"{ToppingType} weight should be in the range [1..50].");
                }
                toppingWeight=value;
            }
        }

        public double ToppingCalories => ToppingWeight * 2 * toppingInformation[ToppingType.ToLower()];

    }
}
