using System;

namespace _08_Factorial_Division
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double firstDigit = double.Parse(Console.ReadLine());
            double secondDigit = double.Parse(Console.ReadLine());

            double firstDigitResult = FirstDigitFactorial(firstDigit);
            double secondDigitResult = SecondDigitFactorial(secondDigit);

            Console.WriteLine($"{firstDigitResult/secondDigitResult:f2}");
            
        }

        private static double SecondDigitFactorial(double secondDigit)
        {
            double result = 1;
            for (int i = 1; i <= secondDigit; i++)
            {
                result *= i;
            }
            return result;
        }

        private static double FirstDigitFactorial(double firstDigit)
        {
            double result = 1;
            for (int i = 1; i <= firstDigit; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}
