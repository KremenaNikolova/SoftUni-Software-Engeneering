using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee:HotBeverage
    {
        public Coffee(string name, decimal price, double milliliters, double coffeeMilliliters, decimal coffeePrice, double caffeine):base(name, price, milliliters)
        {
            CoffeeMilliliters = 50;
            CoffeePrice = 3.50M;
            Caffeine = caffeine;

        }
        public double CoffeeMilliliters { get; set; }
        public decimal CoffeePrice { get; set; }
        public double Caffeine { get; set; }
    }
}
