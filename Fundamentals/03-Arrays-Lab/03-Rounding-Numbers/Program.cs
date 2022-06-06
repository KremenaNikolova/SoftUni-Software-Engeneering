using System;

namespace _03_Rounding_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            double[] numbersOfInput = new double[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                numbersOfInput[i] = double.Parse(input[i]); 
            }
            for (int i = 0; i < numbersOfInput.Length; i++)
            {
                Console.WriteLine($"{numbersOfInput[i]} => {(int)Math.Round(numbersOfInput[i], MidpointRounding.AwayFromZero)}");
            }

        }
    }
}
