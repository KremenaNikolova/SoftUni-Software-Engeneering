using System;

namespace _01_Smallest_of_Three_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            Console.WriteLine(BiggestNumber(firstNumber, secondNumber, thirdNumber));
        }
        static int BiggestNumber(int firstNumber, int secondNumber, int thirdNumber)
        {
            if (firstNumber<secondNumber && firstNumber< thirdNumber)
            {
                return firstNumber;
            }
            else if (secondNumber<firstNumber && secondNumber < thirdNumber)
            {
                return secondNumber;
            }
            else
            {
                return thirdNumber;
            }
        }
    }
}
