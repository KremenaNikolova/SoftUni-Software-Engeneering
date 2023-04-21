using System;
using System.Collections.Generic;
using System.Linq;

namespace BeaverAtWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] pond = new char[size, size];
            int rowPosition = 0;
            int colPosition = 0;
            int branchesCount = 0;
            Stack<char> collectedBranch = new Stack<char>();

            for (int row = 0; row < size; row++)
            {
                char[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    pond[row, col] = input[col];
                    if (pond[row, col] == 'B')
                    {
                        rowPosition = row;
                        colPosition = col;
                    }
                    if (char.IsLetter(pond[row, col]) && char.IsLower(pond[row, col]))
                    {
                        branchesCount++;
                    }
                }
            }
            pond[rowPosition, colPosition] = '-';

            string command = Console.ReadLine();
            while (command != "end" && branchesCount>0)
            {
                switch (command)
                {
                    case "up":
                        rowPosition--;
                        if (!isValidPosition(rowPosition, colPosition, pond))
                        {
                            rowPosition++;
                            if (collectedBranch.Count > 0)
                            {
                                collectedBranch.Pop();
                            }
                        }
                        else if (pond[rowPosition, colPosition] == 'F')
                        {
                            pond[rowPosition, colPosition] = '-';
                            if (rowPosition != 0)
                            {
                                rowPosition = 0;
                                if (pond[rowPosition, colPosition] == 'F')
                                {
                                    pond[rowPosition, colPosition] = '-';
                                    rowPosition = pond.GetLength(0)-1;
                                    if (pond[rowPosition, colPosition] == 'F')
                                    {
                                        pond[rowPosition, colPosition] = '-';
                                        rowPosition = 0;
                                    }
                                    pond[rowPosition, colPosition] = '-';
                                }
                                else
                                {
                                    MoveOnBranch(rowPosition, colPosition, pond, ref collectedBranch, ref branchesCount);
                                }
                            }
                            else
                            {
                                rowPosition = pond.GetLength(0)-1;
                                if (pond[rowPosition, colPosition] == 'F')
                                {
                                    pond[rowPosition, colPosition] = '-';
                                    rowPosition = 0;
                                }
                                else
                                {
                                    MoveOnBranch(rowPosition, colPosition, pond, ref collectedBranch, ref branchesCount);
                                }
                            }
                        }
                        else
                        {
                            MoveOnBranch(rowPosition, colPosition, pond, ref collectedBranch, ref branchesCount);
                        }
                        break;
                    case "down":
                        rowPosition++;
                        if (!isValidPosition(rowPosition, colPosition, pond))
                        {
                            rowPosition--;
                            if (collectedBranch.Count > 0)
                            {
                                collectedBranch.Pop();
                            }
                        }
                        else if (pond[rowPosition, colPosition] == 'F')
                        {
                            pond[rowPosition, colPosition] = '-';
                            if (rowPosition != pond.GetLength(0)-1)
                            {
                                rowPosition = pond.GetLength(0)-1;
                                if (pond[rowPosition, colPosition] == 'F')
                                {
                                    pond[rowPosition, colPosition] = '-';
                                    rowPosition = 0;
                                    if (pond[rowPosition, colPosition] == 'F')
                                    {
                                        pond[rowPosition, colPosition] = '-';
                                        rowPosition = pond.GetLength(0)-1;
                                    }
                                }
                                else
                                {
                                    MoveOnBranch(rowPosition, colPosition, pond, ref collectedBranch, ref branchesCount);
                                }
                            }
                            else
                            {
                                rowPosition = 0;
                                if (pond[rowPosition, colPosition] == 'F')
                                {
                                    pond[rowPosition, colPosition] = '-';
                                    rowPosition = pond.GetLength(0)-1;
                                }
                                else
                                {
                                    MoveOnBranch(rowPosition, colPosition, pond, ref collectedBranch, ref branchesCount);
                                }
                            }
                        }
                        else
                        {
                            MoveOnBranch(rowPosition, colPosition, pond, ref collectedBranch, ref branchesCount);
                        }
                        break;
                    case "left":
                        colPosition--;
                        if (!isValidPosition(rowPosition, colPosition, pond))
                        {
                            colPosition++;
                            if (collectedBranch.Count > 0)
                            {
                                collectedBranch.Pop();
                            }
                        }
                        else if (pond[rowPosition, colPosition] == 'F')
                        {
                            pond[rowPosition, colPosition] = '-';
                            if (colPosition != 0)
                            {
                                colPosition = 0;
                                if (pond[rowPosition, colPosition] == 'F')
                                {
                                    pond[rowPosition, colPosition] = '-';
                                    colPosition = pond.GetLength(1)-1;
                                    if (pond[rowPosition, colPosition] == 'F')
                                    {
                                        pond[rowPosition, colPosition] = '-';
                                        colPosition = 0;
                                    }
                                }
                                else
                                {
                                    MoveOnBranch(rowPosition, colPosition, pond, ref collectedBranch, ref branchesCount);
                                }
                            }
                            else
                            {
                                colPosition = pond.GetLength(1)-1;
                                if (pond[rowPosition, colPosition] == 'F')
                                {
                                    pond[rowPosition, colPosition] = '-';
                                    colPosition = 0;
                                }
                                else
                                {
                                    MoveOnBranch(rowPosition, colPosition, pond, ref collectedBranch, ref branchesCount);
                                }
                            }
                        }
                        else
                        {
                            MoveOnBranch(rowPosition, colPosition, pond, ref collectedBranch, ref branchesCount);
                        }
                        break;
                    case "right":
                        colPosition++;
                        if (!isValidPosition(rowPosition, colPosition, pond))
                        {
                            colPosition--;
                            if (collectedBranch.Count > 0)
                            {
                                collectedBranch.Pop();
                            }
                        }
                        else if (pond[rowPosition, colPosition] == 'F')
                        {
                            pond[rowPosition, colPosition] = '-';
                            if (colPosition != pond.GetLength(1)-1)
                            {
                                colPosition = pond.GetLength(1)-1;
                                if (pond[rowPosition, colPosition] == 'F')
                                {
                                    pond[rowPosition, colPosition] = '-';
                                    colPosition = 0;
                                    if (pond[rowPosition, colPosition] == 'F')
                                    {
                                        pond[rowPosition, colPosition] = '-';
                                        colPosition++;
                                        colPosition = pond.GetLength(1)-1;
                                    }
                                    pond[rowPosition, colPosition] = '-';
                                }
                                else
                                {
                                    MoveOnBranch(rowPosition, colPosition, pond, ref collectedBranch, ref branchesCount);
                                }
                            }
                            else
                            {
                                colPosition = 0;
                                if (pond[rowPosition, colPosition] == 'F')
                                {
                                    pond[rowPosition, colPosition] = '-';
                                    colPosition = pond.GetLength(1)-1;
                                }
                                else
                                {
                                    MoveOnBranch(rowPosition, colPosition, pond, ref collectedBranch, ref branchesCount);
                                }
                            }
                        }
                        else
                        {
                            MoveOnBranch(rowPosition, colPosition, pond, ref collectedBranch, ref branchesCount);
                        }
                        break;
                }
                command = Console.ReadLine();
            }

            if (branchesCount==0)
            {
                Console.WriteLine($"The Beaver successfully collect {collectedBranch.Count} wood branches: {string.Join(", ",collectedBranch.Reverse())}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {branchesCount} branches left.");
            }

            pond[rowPosition, colPosition] = 'B';

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(pond[row,col] + " ");
                }
                Console.WriteLine();
            }


        }
        static bool isValidPosition(int rowPosition, int colPosition, char[,] pond)
        {
            return rowPosition >= 0
                && rowPosition < pond.GetLength(0)
                && colPosition >= 0
                && colPosition < pond.GetLength(1);
        }

        static void MoveOnBranch(int rowPosition, int colPosition, char[,] pond, ref Stack<char> branches, ref int branchesCount)
        {
            if (char.IsLetter(pond[rowPosition, colPosition]) && char.IsLower(pond[rowPosition, colPosition]))
            {
                branches.Push(pond[rowPosition, colPosition]);
                pond[rowPosition, colPosition] = '-';
                branchesCount--;
            }
        }


    }
}
