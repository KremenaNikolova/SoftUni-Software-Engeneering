//Create a program that prints information about food shops in Sofia and the products they store. Until the "Revision" command is received, you will be receiving input in the format: "{shop}, {product}, {price}".Keep in mind that if you receive a shop you already have received, you must collect its product information.
//Your output must be ordered by shop name and must be in the format:
//"{shop}->
//Product: { product}, Price: { price}"
//Note: The price should not be rounded or formatted.


using System;
using System.Collections.Generic;

namespace _04_Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> foodShopsInformation = new SortedDictionary<string, Dictionary<string, double>>();

            string input = Console.ReadLine();
            while (input != "Revision")
            {
                string[] token = input.Split(", ");
                string shop = token[0];
                string product = token[1];
                double price = double.Parse(token[2]);

                if (!foodShopsInformation.ContainsKey(shop))
                {
                    foodShopsInformation.Add(shop, new Dictionary<string, double>());
                    foodShopsInformation[shop].Add(product, price);
                }
                else
                {
                    foodShopsInformation[shop].Add(product, price);
                }

                input = Console.ReadLine();
            }

            foreach (var shop in foodShopsInformation)
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
