using System;

namespace _10_Multiply_Evens_by_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int justNumber = int.Parse(Console.ReadLine());
            justNumber=Math.Abs(justNumber);

            int oddResult = 0;
            int evenResult = 0;
            int multipleResult = 0;

            Console.WriteLine(GetMultipleOfEvenAndOdds(justNumber, evenResult, oddResult));
        }
        static int GetMultipleOfEvenAndOdds(int justNumber, int evenResult, int oddResult)
        {
            int multipleResult = GetSumOfEvenDigits(justNumber, evenResult) * GetSumOfOddDigits(justNumber, oddResult);
            return multipleResult;
        }
        static int GetSumOfEvenDigits(int justNumber, int evenResult)
        {
            while (justNumber>0)
            {
                int lastNumber = justNumber % 10;
                if (lastNumber%2==0)
                {
                    evenResult += lastNumber;
                }
                justNumber = justNumber / 10;
            }
            return evenResult; 
        }
        static int GetSumOfOddDigits(int justNumber, int oddResult)
        {
            while (justNumber > 0)
            {
                int lastNumber = justNumber % 10;
                if (lastNumber % 2 != 0)
                {
                    oddResult += lastNumber;
                }
                justNumber = justNumber / 10;
            }
            return oddResult;
        }
    }
}
