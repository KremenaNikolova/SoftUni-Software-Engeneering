using System;
using System.Linq;

namespace Help_A_Mole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            char[,] matrix = new char[matrixSize, matrixSize];
            int points = 0;

            for (int row = 0; row < matrixSize; row++)
            {
                string input = Console.ReadLine();
                char[] charrs = input.ToCharArray();
                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = charrs[col];
                }
            }
            int rowIndex=0;
            int columnIndex=0;
            char specialChar = 'M';

            SpecialSymbolIndex(matrix, rowIndex, columnIndex, specialChar);

            string command = Console.ReadLine();

            while (command!="End")
            {
                switch (command)
                {
                    case "up":
                        Up(matrix, rowIndex, columnIndex);
                        break;
                    case "down":
                        break;
                    case "right":
                        break;
                    case "left":
                        break;
                    default:
                        break;
                }

                command = Console.ReadLine();
            }
            static void SpecialSymbolIndex(char[,] matrix, int rowIndex, int columnIndex, char specialChar)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int cow = 0; cow < matrix.GetLength(1); cow++)
                    {
                        if (matrix[row, cow] == specialChar)
                        {
                            rowIndex = row;
                            columnIndex = cow;
                        }
                    }
                }
            }

            static void Up(char[,] matrix, int rowIndex, int columnIndex)
            {
                if (rowIndex-1>=0)
                {
                    matrix[rowIndex, columnIndex] = '-';
                    rowIndex--;
                    if (matrix[rowIndex, columnIndex]=='S')
                    {
                        ReplaceS(matrix);
                    }
                    matrix[rowIndex, columnIndex] = 'M';

                }
            }
            static void Down(char[,] matrix, int rowIndex, int columnIndex)
            {
                if (rowIndex + 1 >= matrix.GetLength(1))
                {
                    matrix[rowIndex, columnIndex] = '-';
                    rowIndex--;
                    if (matrix[rowIndex, columnIndex] == 'S')
                    {
                        ReplaceS(matrix);
                    }
                    matrix[rowIndex, columnIndex] = 'M';

                }
            }

            static void ReplaceS(char[,] matrix)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == 'S')
                        {
                            matrix[row, col] = '-';
                        }
                    }
                }
            }

            static void CheckChar(char[,]matrix, int rowIndex, int columnIndex, int points)
            {
                if (char.IsDigit(matrix[rowIndex, columnIndex]))
                {
                    points+=(int)matrix[rowIndex, columnIndex];
                }
                else if (true)
                {

                }
            }
        }
    }
}
