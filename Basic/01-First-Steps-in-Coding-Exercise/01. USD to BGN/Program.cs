using System;

namespace _01._3_PB_CSharp_First_Steps_in_Coding_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            double bgn = double.Parse(Console.ReadLine());
            double usd = 1.79549;

            double sum = bgn * usd;

            Console.WriteLine(sum);
        }
    }
}

