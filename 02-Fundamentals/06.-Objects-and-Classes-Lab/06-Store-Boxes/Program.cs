using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_Store_Boxes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Box> products = new List<Box>();
            while (true)
            {
                
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }
                string[] inputToTokens = input.Split();

                //string serialNumber = inputToTokens[0];
                //string itemName = inputToTokens[1];
                //int itemQuant = int.Parse(inputToTokens[2]);
                //decimal itemValue = decimal.Parse(inputToTokens[3]);

                Box box = new Box
                {
                    SerialNumber = inputToTokens[0],
                    Item = new Item(inputToTokens[1], decimal.Parse(inputToTokens[3])),
                    ItemQuantity = int.Parse(inputToTokens[2])
                };

                products.Add(box);
            }

            List<Box> sortBoxes = products.OrderByDescending(byPrice => byPrice.PriceForBox).ToList();

            foreach (Box box in sortBoxes)
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.PriceForBox:f2}"); 
            }

        }
    }

    public class Item
    {
        public Item(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class Box
    {

        public string SerialNumber { get; set; }
        public Item Item { get; set; }
        public int ItemQuantity { get; set; }
        public decimal PriceForBox
        {
            get
            {
                return this.ItemQuantity * this.Item.Price;
            }
        }
    }
}
