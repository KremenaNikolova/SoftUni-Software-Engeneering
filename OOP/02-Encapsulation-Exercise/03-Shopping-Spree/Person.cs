using System;
using System.Collections.Generic;
using System.Text;

namespace _03_Shopping_Spree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;

        public Person()
        {
            bag = new List<Product>();
        }
        public Person(string name, decimal money):this()
        {
            Name = name;
            Money = money;
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

        public decimal Money 
        {
            get { return money; }
            private set
            {
                if (value < 0)
                {
                    throw new Exception("Money cannot be negative");
                }
                money = value;
            }
        }

        public void AddPerson(Product product)
        {
            if (money>=product.Cost)
            {
                bag.Add(product);
                money -= product.Cost;
                Console.WriteLine($"{this.Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{name} can't afford {product.Name}");
            }
            
        }

        public override string ToString()
        {
            if (bag.Count==0)
            {
                return $"{Name} - Nothing bought";
            }
            return $"{Name} - {string.Join(", ", bag)}";
        }

    }
}
