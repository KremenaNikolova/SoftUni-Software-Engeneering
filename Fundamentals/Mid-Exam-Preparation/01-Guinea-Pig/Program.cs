using System;

namespace _01_Guinea_Pig
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double quantityOfFood = double.Parse(Console.ReadLine());
            double quantityOfHay = double.Parse(Console.ReadLine());
            double quantityOfCover = double.Parse(Console.ReadLine());
            double guineasWeight = double.Parse(Console.ReadLine());

            
            double quantityOfCoverInGrams = quantityOfCover * 1000;
            double guineasWeightInGrams = guineasWeight * 1000;

            for (int i = 1; i <= 30; i++)
            {
                quantityOfFood -= 0.3;
                if (i%2==0)
                {
                    quantityOfHay = quantityOfHay - (quantityOfFood * 0.05);
                }
                if (i % 3 == 0)
                {

                    quantityOfCoverInGrams = quantityOfCoverInGrams-guineasWeightInGrams / 3;
                }

                if (quantityOfFood<0 || quantityOfHay<0 || quantityOfCoverInGrams < 0)
                {
                    Console.WriteLine("Merry must go to the pet store!");
                    return;
                }
            }
            quantityOfCover = quantityOfCoverInGrams / 1000;
            Console.WriteLine($"Everything is fine! Puppy is happy! Food: {quantityOfFood:f2}, Hay: {quantityOfHay:f2}, Cover: {quantityOfCover:f2}.");
        }
    }
}
