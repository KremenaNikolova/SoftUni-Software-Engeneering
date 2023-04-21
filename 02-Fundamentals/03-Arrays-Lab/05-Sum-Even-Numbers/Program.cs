using System;

namespace _05_Sum_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] randomNumbers = Console.ReadLine().Split();
            int[] stringToNumber = new int[randomNumbers.Length];
            //int sumOddNumbers = 0;
            int sumEvenNumbers = 0;


            for (int i = 0; i < randomNumbers.Length; i++)
            {
                stringToNumber[i] = int.Parse(randomNumbers[i]);
                if (stringToNumber[i]%2==0)
                {
                    sumEvenNumbers += stringToNumber[i];
                }
                //else
                //{
                //    sumOddNumbers += stringToNumber[i];
                //}
            }
            Console.WriteLine(sumEvenNumbers);

        }
    }
}
