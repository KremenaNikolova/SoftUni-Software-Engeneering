using System;

namespace _02_Tax_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(">>");

            double totalTaxCollection = 0;

            for (int i = 0; i < input.Length; i++)
            {
                string output = input[i];
                string[] tokens = output.Split();

                string carType=tokens[0];
                int yearsTheTaxShouldBePaid=int.Parse(tokens[1]);
                int kilometersTraveled=int.Parse(tokens[2]);

                double tax = 0;
                double totalTax = 0;

                if (carType=="family")
                {
                    tax = 50;
                    totalTax = (kilometersTraveled / 3000) * 12 + (tax - 5 * yearsTheTaxShouldBePaid);
                    Console.WriteLine($"A {carType} car will pay {totalTax:f2} euros in taxes.");
                }
                else if (carType=="heavyDuty")
                {
                    tax = 80;
                    totalTax = (kilometersTraveled / 9000) * 14 + (tax - 8 * yearsTheTaxShouldBePaid);
                    Console.WriteLine($"A {carType} car will pay {totalTax:f2} euros in taxes.");
                }
                else if (carType=="sports")
                {
                    tax = 100;
                    totalTax = (kilometersTraveled / 2000) * 18 + (tax - 9 * yearsTheTaxShouldBePaid);
                    Console.WriteLine($"A {carType} car will pay {totalTax:f2} euros in taxes.");
                }
                else
                {
                    Console.WriteLine("Invalid car type.");
                    continue;
                }
                totalTaxCollection += totalTax;
            }
            Console.WriteLine($"The National Revenue Agency will collect {totalTaxCollection:f2} euros in taxes.");
        }
    }
}
