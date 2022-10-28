using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Fish:MainDish
    {
        public Fish(string name, decimal price, double grams) : base(name, price, grams)
        {
            Grams = 22;
        }
    }
}
