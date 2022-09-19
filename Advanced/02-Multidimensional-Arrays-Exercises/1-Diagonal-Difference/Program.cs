using System;
using System.Linq;

namespace _1_Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int[,] matrix = new int[matrixSize, matrixSize];

            for (int row = 0; row < matrixSize; row++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int sumLeftToRightDiagonal = 0;
            int sumRightToLeftDiagonal = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (col==row)
                    {
                        sumLeftToRightDiagonal += matrix[row, col];
                    }
                }
            }

            for (int row = matrix.GetLength(0)-1; row >= 0; row--)
            {
                int col = matrix.GetLength(1) - 1;
                sumRightToLeftDiagonal += matrix[row, col - row];
            }

            Console.WriteLine(Math.Abs(sumLeftToRightDiagonal-sumRightToLeftDiagonal));
        }
    }
}
