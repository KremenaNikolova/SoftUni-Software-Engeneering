using System;
using System.Linq;

namespace _2_Squares_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            char[,] matrix = new char[dimensions[0], dimensions[1]];
            int counter = 0;

            if (matrix.GetLength(0)<1 || matrix.GetLength(1)<1)
            {
                Console.WriteLine("0");
                return;
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (col+1<matrix.GetLength(1) && row+1<matrix.GetLength(0))
                    {
                        if (isEqualChars(row, col, matrix))
                        {
                            counter++;
                        }
                    }
                }
            }

            Console.WriteLine(counter);

        }

        static bool isEqualChars(int row, int col, char[,] matrix)
        {
            return
                matrix[row, col] == matrix[row, col + 1]
                && matrix[row, col] == matrix[row + 1, col]
                && matrix[row, col] == matrix[row + 1, col + 1];
        }
    }
}

