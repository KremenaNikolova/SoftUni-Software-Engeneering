using System;

namespace WallDestroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] wall = new char[size, size];

            int rowPosition = 0;
            int colPosition = 0;
            int countOfHoles = 1;
            int countOfRods = 0;

            for (int row = 0; row < size; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    wall[row, col] = input[col];
                    if (wall[row, col] == 'V')
                    {
                        rowPosition = row;
                        colPosition = col;
                        wall[row, col] = '*';
                    }
                }
            }

            string command = Console.ReadLine();
            while (command != "End")
            {
                switch (command)
                {
                    case "up":
                        rowPosition--;
                        if (isValidPosition(rowPosition, colPosition, wall))
                        {
                            if (wall[rowPosition, colPosition] == 'R')
                            {
                                Console.WriteLine("Vanko hit a rod!");
                                countOfRods++;
                                rowPosition++;
                            }
                            else
                            {
                                MoveOn(rowPosition, colPosition, ref countOfHoles, wall);
                            }
                        }
                        else
                        {
                            rowPosition++;
                        }
                        break;
                    case "down":
                        rowPosition++;
                        if (isValidPosition(rowPosition, colPosition, wall))
                        {
                            if (wall[rowPosition, colPosition] == 'R')
                            {
                                Console.WriteLine("Vanko hit a rod!");
                                countOfRods++;
                                rowPosition--;
                            }
                            else
                            {
                                MoveOn(rowPosition, colPosition, ref countOfHoles, wall);
                            }
                        }
                        else
                        {
                            rowPosition--;
                        }
                        break;
                    case "left":
                        colPosition--;
                        if (isValidPosition(rowPosition, colPosition, wall))
                        {
                            if (wall[rowPosition, colPosition] == 'R')
                            {
                                Console.WriteLine("Vanko hit a rod!");
                                countOfRods++;
                                colPosition++;
                            }
                            else
                            {
                                MoveOn(rowPosition, colPosition, ref countOfHoles, wall);
                            }
                        }
                        else
                        {
                            colPosition++;
                        }
                        break;
                    case "right":
                        colPosition++;
                        if (isValidPosition(rowPosition, colPosition, wall))
                        {
                            if (wall[rowPosition, colPosition] == 'R')
                            {
                                Console.WriteLine("Vanko hit a rod!");
                                countOfRods++;
                                colPosition--;
                            }
                            else
                            {
                                MoveOn(rowPosition, colPosition, ref countOfHoles, wall);
                            }
                        }
                        else
                        {
                            colPosition--;
                        }
                        break;
                }
                if (wall[rowPosition, colPosition] == 'C')
                {
                    wall[rowPosition, colPosition] = 'E';
                    countOfHoles++;
                    Console.WriteLine($"Vanko got electrocuted, but he managed to make {countOfHoles} hole(s).");
                    break;
                }

                command = Console.ReadLine();
            }

            
            if (command == "End")
            {
                wall[rowPosition, colPosition] = 'V';
                Console.WriteLine($"Vanko managed to make {countOfHoles} hole(s) and he hit only {countOfRods} rod(s).");
            }

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(wall[row, col]);
                }
                Console.WriteLine();
            }


        }
        static bool isValidPosition(int rowPosition, int colPosition, char[,] wall)
        {
            return rowPosition < wall.GetLongLength(0)
                && rowPosition >= 0
                && colPosition < wall.GetLongLength(1)
                && colPosition >= 0;
        }
        static void MoveOn(int rowPosition, int colPosition, ref int countOfHoles, char[,] wall)
        {
            if (wall[rowPosition, colPosition] == '*')
            {
                Console.WriteLine($"The wall is already destroyed at position [{rowPosition}, {colPosition}]!");
            }
            else if (wall[rowPosition, colPosition] != 'C')
            {
                wall[rowPosition, colPosition] = '*';
                countOfHoles++;
            }
        }
    }
}
