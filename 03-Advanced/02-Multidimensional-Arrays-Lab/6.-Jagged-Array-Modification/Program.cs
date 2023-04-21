using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowsSize = int.Parse(Console.ReadLine());
            int[][] matrix = new int[rowsSize][];

            for (int row = 0; row < rowsSize; row++)
            {
                int[] colsSize = Console.ReadLine().Split().Select(int.Parse).ToArray();
                matrix[row] = new int[colsSize.Length]; 
                for (int col = 0; col < colsSize.Length; col++)
                {
                    matrix[row][col] = colsSize[col];
                }
            }

            string[] command = Console.ReadLine().Split();
            while (command[0]!="END")
            {
                string action = command[0];
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                int num = int.Parse(command[3]);
                if (row < rowsSize && col < matrix.GetLength(0) &&row>=0 && col>=0)
                {
                    if (action == "Add")
                    {
                        matrix[row][col] += num;
                    }
                    else if (action == "Subtract")
                    {
                        matrix[row][col] -= num;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }
                command = Console.ReadLine().Split();
            }

            for (int row = 0; row < rowsSize; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write($"{matrix[row][col]} ");
                }
                Console.WriteLine();
            }

        }
    }
}
