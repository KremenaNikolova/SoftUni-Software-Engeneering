using System;

namespace _10_Top_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            
            for (int number = 0; number <= input; number++)
            {
                bool isDivisibleByEight = CheckDivisibleByEight(number);
                bool isAtLeastOneOddDigit = CheckForOddDigit(number);

                if (isDivisibleByEight == true && isAtLeastOneOddDigit == true)
                {
                    Console.WriteLine(number);
                }
            }
        }

        private static bool CheckForOddDigit(int number)
        {
            string inputToString = number.ToString();
            for (int i = 0; i < inputToString.Length; i++)
            {
                if (inputToString[i]%2!=0)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool CheckDivisibleByEight(int number)
        {
            string inputToString = number.ToString();
            int sumOfEachNumber = 0;
            for (int i = 0; i < inputToString.Length; i++)
            {
                sumOfEachNumber+=inputToString[i];
            }
            if (sumOfEachNumber%8==0)
            {
                return true;
            }
            return false;
        }
    }
}
