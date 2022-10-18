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

            int rowPosition = 0;
            int colPosition = 0;
            int points = 0;

            for (int row = 0; row < matrixSize; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = input[col];
                    if (input[col]=='M')
                    {
                        rowPosition = row;
                        colPosition = col;
                    }
                }
            }
            matrix[rowPosition, colPosition] = '-';


            string command = Console.ReadLine();
            while (command !="End" && points<25)
            {
                int oldRowPosition = rowPosition;
                int oldColPosition = colPosition;
                switch (command)
                {
                    case "up":
                        rowPosition--;
                        break;
                    case "down":
                        rowPosition++;
                        break;
                    case "left":
                        colPosition--;
                        break;
                    case "right":
                        colPosition++;
                        break;
                    default:
                        break;
                }
                if (rowPosition<0||colPosition<0 || rowPosition>=matrixSize || colPosition>=matrixSize)
                {
                    Console.WriteLine("Don't try to escape the playing field!");
                    rowPosition = oldRowPosition;
                    colPosition = oldColPosition;
                }

                else if (matrix[rowPosition,colPosition]=='S')
                {
                    matrix[rowPosition, colPosition] = '-';
                    points -= 3;
                    for (int row = 0; row < matrixSize; row++)
                    {
                        for (int col = 0; col < matrixSize; col++)
                        {
                            if (matrix[row, col] == 'S')
                            {
                                rowPosition = row;
                                colPosition = col;
                                matrix[row, col] = '-';
                                break; 
                            }
                        }
                    }
                }
                else if (char.IsDigit(matrix[rowPosition, colPosition]))
                {
                    points +=int.Parse(matrix[rowPosition, colPosition].ToString());
                    matrix[rowPosition, colPosition] = '-';
                }

                //if the M is out of matrix print "Don't try to escape the playing field!" and continue with command
                // if 'M' is at position 'S' remove 3 points and remove all 'S'
                command = Console.ReadLine();
            }
            matrix[rowPosition, colPosition] = 'M';

            if (points>=25)
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
            }
            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {points} points.");
            }
            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }


           
            
        }
    }
}
