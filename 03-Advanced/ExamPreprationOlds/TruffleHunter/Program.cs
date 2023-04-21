using System;
using System.Linq;

namespace TruffleHunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] forest = new char[size, size];

            int blackTruffleCount = 0;
            int summerTruffleCount = 0;
            int whiteTruffleCount = 0;
            int wildBoarTrufflesCount = 0;

            for (int row = 0; row < size; row++)
            {
                char[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    forest[row, col] = input[col];
                }
            }

            string command = Console.ReadLine();
            while (command != "Stop the hunt")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);

                switch (action)
                {
                    case "Collect":
                        CheckPosition(row, col, ref whiteTruffleCount, ref blackTruffleCount, ref summerTruffleCount, forest);
                        forest[row, col] = '-';
                        break;
                    case "Wild_Boar":
                        string direction = tokens[3];
                        int copyOfBlackTrufflesCount = blackTruffleCount;
                        int copyOfSummerTrufflesCount = summerTruffleCount;
                        int copyOfWhiteTrufflesCount = whiteTruffleCount;
                        
                        CheckPosition(row, col, ref whiteTruffleCount, ref blackTruffleCount, ref summerTruffleCount, forest);
                        forest[row, col] = '-';
                        switch (direction)
                        {
                            case "up":
                                for (int rowCount = row; rowCount >= 0; rowCount-=2)
                                {
                                    CheckPosition(rowCount, col, ref whiteTruffleCount, ref blackTruffleCount, ref summerTruffleCount, forest);
                                    forest[rowCount, col] = '-';
                                }
                                break;
                            case "down":
                                for (int rowCount = row; rowCount< forest.GetLength(0); rowCount+=2)
                                {
                                    CheckPosition(rowCount, col, ref whiteTruffleCount, ref blackTruffleCount, ref summerTruffleCount, forest);
                                    forest[rowCount, col] = '-';
                                }
                                break;
                            case "left":
                                for (int colCount = col; colCount >= 0; colCount-=2)
                                {
                                    CheckPosition(row, colCount, ref whiteTruffleCount, ref blackTruffleCount, ref summerTruffleCount, forest);
                                    forest[row, colCount] = '-';
                                }
                                break;
                            case "right":
                                for (int colCount = col; colCount <forest.GetLength(1); colCount+=2)
                                {
                                    CheckPosition(row, colCount, ref whiteTruffleCount, ref blackTruffleCount, ref summerTruffleCount, forest);
                                    forest[row, colCount] = '-';
                                }
                                break;
                        }
                        wildBoarTrufflesCount+=(blackTruffleCount+summerTruffleCount+whiteTruffleCount)-(copyOfWhiteTrufflesCount+ copyOfBlackTrufflesCount + copyOfSummerTrufflesCount);
                        blackTruffleCount = copyOfBlackTrufflesCount;
                        summerTruffleCount = copyOfSummerTrufflesCount;
                        whiteTruffleCount = copyOfWhiteTrufflesCount;
                        break;
                        
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Peter manages to harvest {blackTruffleCount} black, {summerTruffleCount} summer, and {whiteTruffleCount} white truffles.");
            Console.WriteLine($"The wild boar has eaten {wildBoarTrufflesCount} truffles.");

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(forest[row,col] + " ");
                }
                Console.WriteLine();
            }


        }
        //static bool isValidPosition(int row, int col, char[,] forest)
        //{
        //    return row >= 0
        //        && row < forest.GetLength(0)
        //        && col >= 0
        //        && col < forest.GetLength(1);
        //}
        static void CheckPosition(int row, int col, ref int whiteTruffleCount, ref int blackTruffleCount, ref int summerTruffleCount, char[,] forest)
        {
            if (forest[row, col] == 'B')
            {
                blackTruffleCount++;
            }
            else if (forest[row, col] == 'S')
            {
                summerTruffleCount++;
            }
            else if (forest[row, col] == 'W')
            {
                whiteTruffleCount++;
            }
        }
    }
}
