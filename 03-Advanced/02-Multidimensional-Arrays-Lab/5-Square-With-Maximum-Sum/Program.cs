using System;
using System.Linq;

namespace _5_Square_With_Maximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];
            int[,] matrix = new int[rows,cols];
            int rowSquare = 2;
            int colSquare = 2;
            int sumMax = 0;
            int maxRow = 0;
            int maxCol = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row,col] = input[col];
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row + rowSquare-1<matrix.GetLength(0) && col + colSquare-1<matrix.GetLength(1))
                    {
                        int sum = matrix[row, col] + matrix[row + 1, col] + matrix[row, col + 1] + matrix[row + 1, col + 1];
                        if (sum>sumMax)
                        {
                            sumMax = sum;
                            maxRow = row;
                            maxCol = col;
                        }
                    }
                }
            }

            for (int row = maxRow; row < maxRow+rowSquare; row++)
            {
                for (int col = maxCol; col < maxCol+colSquare; col++)
                {
                    Console.Write($"{matrix[row,col]} ");
                }
                Console.WriteLine();
            }
            //Console.WriteLine(matrix[maxRow,maxCol]);
            Console.WriteLine(sumMax);



        }
    }
}
