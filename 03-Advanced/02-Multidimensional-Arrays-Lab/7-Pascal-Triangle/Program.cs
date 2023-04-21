using System;

namespace _7_Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long numberOfRows = int.Parse(Console.ReadLine());
            long[][] pascalTriagnle = new long[numberOfRows][];

            for (int row = 0; row < numberOfRows; row++)
            {
                pascalTriagnle[row] = new long[row+1];
                for (int col = 0; col <= pascalTriagnle[row].Length; col++)
                {
                    if (col==0)
                    {
                        pascalTriagnle[row][col] = 1;
                        pascalTriagnle[row][pascalTriagnle[row].Length-1] = 1;
                    }
                    else if (col < pascalTriagnle[row].Length-1)
                    {
                        pascalTriagnle[row][col] = pascalTriagnle[row - 1][col-1] + pascalTriagnle[row - 1][col];
                    }
                }
            }

            for (int row = 0; row < numberOfRows; row++)
            {
                for (int col = 0; col < pascalTriagnle[row].Length; col++)
                {
                    Console.Write($"{pascalTriagnle[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
