using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string[,] matrix = new string[dimensions[0], dimensions[1]];
            string input = Console.ReadLine();
            Queue<char> queue = new Queue<char>(input.ToCharArray());

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row%2==0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        char currCharr = queue.Dequeue();
                        matrix[row, col] = currCharr.ToString();
                        queue.Enqueue(currCharr);
                    }
                }
                else
                {
                    for (int col = matrix.GetLength(1)-1; col >= 0; col--)
                    {
                        char currCharr = queue.Dequeue();
                        matrix[row, col] = currCharr.ToString();
                        queue.Enqueue(currCharr);
                    }
                }
                
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}
