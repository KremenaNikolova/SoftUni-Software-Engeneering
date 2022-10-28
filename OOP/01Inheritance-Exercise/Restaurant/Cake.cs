using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    internal class Cake:Dessert
    {
        public Cake(string name, decimal price, double grams, double calories, decimal cakePrice) : base(name, price, grams, calories)
        {
            Price = cakePrice;
            Grams = 250;
            Calories = 1000;
            CakePrice = 5M;
        }
        public decimal CakePrice { get; set; }

    }
}
