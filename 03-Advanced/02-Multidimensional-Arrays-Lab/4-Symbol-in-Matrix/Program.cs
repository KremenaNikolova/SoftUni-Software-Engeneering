using System;
using System.Linq;

namespace _4_Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            char[,] matrix = new char[matrixSize, matrixSize];

            for (int row = 0; row < matrixSize; row++)
            {
                string input = Console.ReadLine();
                char[] splitedInput = input.ToCharArray();
                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = splitedInput[col];
                }
            }
            char check = char.Parse(Console.ReadLine());
            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    if (matrix[row,col]==check)
                    {
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                }
            }
            Console.WriteLine($"{check} does not occur in the matrix");

        }
    }
}
