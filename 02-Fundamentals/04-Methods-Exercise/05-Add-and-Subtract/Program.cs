using System;

namespace _05_Add_and_Subtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());
            int numberThree = int.Parse(Console.ReadLine());
            int result = Sum(numberOne,numberTwo);

            Sum(numberOne, numberTwo);
            Substract(result, numberThree);
        }

        private static void Substract(int result, int numberThree)
        {
            int substract = result - numberThree;
            Console.WriteLine(substract); 
        }

        private static int Sum(int numberOne, int numberTwo)
        {
            int sum = numberOne + numberTwo;
            return sum;
        }
    }
}
