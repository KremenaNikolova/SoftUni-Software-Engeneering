using System;
using System.Linq;

namespace _4_Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string[,] matrix = new string[dimensions[0], dimensions[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row,col] = input[col];
                }
            }

            string command = Console.ReadLine();
            while (command!="END")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length<5 || tokens[0]!="swap" || tokens.Length>5)
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                { //have to swap row1 and col1 with row2 and col2
                    int row1 = int.Parse(tokens[1]);
                    int col1 = int.Parse (tokens[2]);

                    int row2 = int.Parse(tokens[3]);
                    int col2 = int.Parse(tokens[4]);

                    if (row1 >= matrix.GetLength(0) || row2 >= matrix.GetLength(0) || col1 >= matrix.GetLength(1) || col2 >= matrix.GetLength(1))
                    {
                        Console.WriteLine("Invalid input!");
                    }
                    else
                    {
                        Swap(row1, col1, row2, col2, matrix);
                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                Console.Write($"{matrix[row, col]} ");
                            }
                            Console.WriteLine();
                        }
                    }
                }
                command = Console.ReadLine();
            }
            
        }
        static void Swap(int row1, int col1, int row2, int col2, string[,] matrix)
        {
            string firstNumPositionCopy = matrix[row1, col1];
            matrix[row1, col1] = matrix[row2, col2];
            matrix[row2, col2] = firstNumPositionCopy;
            return;

        }
    }
}
