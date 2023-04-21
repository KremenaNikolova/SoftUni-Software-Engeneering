using System;
using System.Linq;

namespace _1_Sum_Matrix_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            int[,] matrix = new int[rows, cols];

            

            for (int row = 0; row < rows; row++)
            {
                int[] rowsInput = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowsInput[col];
                }
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int sum = 0;
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    sum += matrix[col, row];
                }
                Console.WriteLine(sum);
            }

            
        }
    }
}
