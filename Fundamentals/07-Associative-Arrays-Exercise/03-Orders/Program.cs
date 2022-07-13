using System;
using System.Collections.Generic;

namespace _03_Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> productsQuantity = new Dictionary<string, int>();
            Dictionary<string, decimal> productsPrice = new Dictionary<string, decimal>();

            while (true)
            {
                string[] input = Console.ReadLine().Split();

                string nameOfProduct = input[0];
                if (nameOfProduct=="buy")
                {
                    break;
                }

                decimal price = decimal.Parse(input[1]);
                int quantity = int.Parse(input[2]);

                if (!productsQuantity.ContainsKey(nameOfProduct))
                {
                    productsQuantity.Add(nameOfProduct, quantity);
                    productsPrice.Add(nameOfProduct, price);
                }
                else
                {
                    productsQuantity[nameOfProduct] += quantity;
                    productsPrice[nameOfProduct] = price;
                }
                
            }

            foreach (var quantity in productsQuantity)
            {
                foreach (var price in productsPrice)
                {
                    if (quantity.Key == price.Key)
                    {
                        Console.WriteLine($"{quantity.Key} -> {quantity.Value * price.Value}");
                    }
                }
            }


        }
    }
}
