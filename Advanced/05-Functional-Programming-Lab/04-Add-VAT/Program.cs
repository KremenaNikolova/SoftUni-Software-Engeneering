//Create a program that reads one line of double prices separated by ", ". Print the prices with added VAT for all of them.
//Format them to 2 signs after the decimal point. The order of the prices must be the same.
//VAT is equal to 20% of the price.


using System;
using System.Linq;

namespace _04_Add_VAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(x=>x+=x*0.2)
                .ToArray();

            foreach (var price in input)
            {
                Console.WriteLine($"{price:f2}");
            }
        }
    }
}
