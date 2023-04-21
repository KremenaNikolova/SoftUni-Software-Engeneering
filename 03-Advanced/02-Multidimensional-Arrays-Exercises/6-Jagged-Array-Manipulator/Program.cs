using System;
using System.Linq;

namespace _6_Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine()); //5 имаме 5 реда в матрицата
            int[][] matrix = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                matrix[row] = input;
            }

            for (int row = 0; row < matrix.Length - 1; row++)
            {
                if (matrix[row].Length == matrix[row + 1].Length)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] *= 2;
                        matrix[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] /= 2;
                    }
                    for (int col = 0; col < matrix[row+1].Length; col++)
                    {
                        matrix[row + 1][col] /= 2;
                    }
                }
            }

            string command = Console.ReadLine();
            while (command!="End")
            {
                string[] token = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = token[0];
                int row = int.Parse(token[1]);
                int col = int.Parse((token[2]));
                int value = int.Parse(token[3]);

                if (action=="Add")
                {
                    if (isValid(row,col,matrix))
                    {
                        matrix[row][col] += value;
                    }
                }
                else if (action== "Subtract")
                {
                    if (isValid(row, col, matrix))
                    {
                        matrix[row][col] -= value;
                    }
                }

                command = Console.ReadLine();
            }
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write($"{matrix[row][col]} ");
                }
                Console.WriteLine();
            }
        }

        static bool isValid(int row, int col, int[][] matrix)
        {
            if (row<matrix.Length && row>=0)
            {
                if (matrix[row].Length>col && col>=0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
