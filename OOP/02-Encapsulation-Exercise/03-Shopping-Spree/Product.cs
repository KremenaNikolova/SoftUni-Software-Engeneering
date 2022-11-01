using System;
using System.Collections.Generic;
using System.Text;

namespace _03_Shopping_Spree
{
    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name 
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Name cannot be empty");
                }
                name = value;
            } 
        }
        public decimal Cost 
        {
            get { return cost; }
            private set
            {
                if (value<0)
                {
                    throw new Exception("Money cannot be negative");
                }
                cost = value;
            }
        }

        public override string ToString()
        {
            return name;
        }
    }
}
