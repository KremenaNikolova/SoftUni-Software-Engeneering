using System;

namespace _02PoundsToDollars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal dolars = decimal.Parse(Console.ReadLine());
            decimal paunds = 1.31M;

            decimal dolarsToPaumds = dolars * paunds;

            Console.WriteLine($"{dolarsToPaumds:f3}");

        }
    }
}
