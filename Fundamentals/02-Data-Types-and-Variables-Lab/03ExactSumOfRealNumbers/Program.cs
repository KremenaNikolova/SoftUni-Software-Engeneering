using System;

namespace _03ExactSumOfRealNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countNumbers = int.Parse(Console.ReadLine());
            decimal sum = 0;

            for (int counter = 0; counter < countNumbers; counter++)
            {
                decimal number = decimal.Parse(Console.ReadLine());
                sum = sum + number;
            }
            Console.WriteLine(sum);
        }
    }
}
