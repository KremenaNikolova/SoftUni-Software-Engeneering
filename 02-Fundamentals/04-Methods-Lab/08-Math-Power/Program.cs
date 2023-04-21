using System;

namespace _08_Math_Power
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double baseNumber = double.Parse(Console.ReadLine());
            int powerNumber = int.Parse(Console.ReadLine());

            Console.WriteLine(ResultOfNumbers(baseNumber, powerNumber)); 
        }
        static double ResultOfNumbers(double baseNumber, int powerNumber)
        {
            //double result = Math.Pow(baseNumber, power);
            double result = 1;
            for (int i = 1; i <= powerNumber; i++)
            {
                result *= baseNumber;
            }
            return result;
        }
    }
}
