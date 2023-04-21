using System;

namespace _05_Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string typeOfProduct = Console.ReadLine();
            int quantityOfTheProduct = int.Parse(Console.ReadLine());
            double price = 0;
            double result = 0;

            if (typeOfProduct=="coffee")
            {
                price = 1.50;
            }
            else if (typeOfProduct=="water")
            {
                price = 1.00;
            }
            else if (typeOfProduct=="coke")
            {
                price = 1.40;
            }
            else if (typeOfProduct=="snacks")
            {
                price = 2.00;
            }

            FinalPrice(price, quantityOfTheProduct, result);
        }

        static void FinalPrice(double price, int quantityOfTheProduct, double result)
        {
            result = price * quantityOfTheProduct;
            Console.WriteLine($"{result:f2}");
        }
    }
}
