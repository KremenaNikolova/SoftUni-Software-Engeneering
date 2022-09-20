using System;
using System.Linq;

namespace _3_Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimension = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] matrix = new int[dimension[0], dimension[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            //Print the elements of the 3 x 3 square as a matrix, along with their sum.
            int maxSum = 0;
            int rowIndex = 0;
            int colIndex = 0;

            for (int row = 0; row < matrix.GetLength(0)-2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1)-2; col++)
                {
                    if (SumSquareMatrix(row, col, matrix)>maxSum)
                    {
                        maxSum = SumSquareMatrix(row, col, matrix);
                        rowIndex = row;
                        colIndex = col;
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            for (int row = rowIndex; row <= rowIndex+2; row++)
            {
                for (int col = colIndex; col <= colIndex+2; col++)
                {
                    Console.Write($"{matrix[row,col]} ");
                }
                Console.WriteLine();
            }

        }

        static int SumSquareMatrix(int row, int col,  int[,] matrix)
        {
            return 
                  matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col +2];
            

        }
    }
}

