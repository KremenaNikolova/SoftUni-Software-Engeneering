using System;

namespace _03_Calculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string action = Console.ReadLine();
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            if (action=="add")
            {
                Add(firstNumber, secondNumber);
            }
            else if (action=="multiply")
            {
                Multiply(firstNumber, secondNumber);
            }
            else if (action=="subtract")
            {
                Subtract(firstNumber, secondNumber);
            }
            else if (action=="divide")
            {
                Divide(firstNumber, secondNumber);
            }

        }
        static void Add(int firstNumber, int secondNumber)
        {
            Console.WriteLine(firstNumber+secondNumber);
        }
        static void Multiply(int firstNumber, int secondNumber)
        {
            Console.WriteLine(firstNumber*secondNumber);
        }
        static void Subtract(int firstNumber, int secondNumber)
        {
            Console.WriteLine(firstNumber-secondNumber);
        }
        static void Divide(int firstNumber, int secondNumber)
        {
            Console.WriteLine(firstNumber/secondNumber);
        }
    }
}
