using System;
using System.Linq;

namespace _7_Knight_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dimensions = int.Parse(Console.ReadLine());
            char[,] chessBoard = new char[dimensions, dimensions];
            int removedKnights =0;
            int mostAttacks = 0;
            int mostRow = 0;
            int mostCol = 0;

            for (int row = 0; row < chessBoard.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                char[] inputChars = input.ToCharArray();
                for (int col = 0; col < chessBoard.GetLength(1); col++)
                {
                    chessBoard[row, col] = inputChars[col];
                }
            }
            if (dimensions<3)
            {
                Console.WriteLine('0');
                return;
            }

            while (true)
            {
                for (int row = 0; row < chessBoard.GetLength(0); row++)
                {
                    for (int col = 0; col < chessBoard.GetLength(1); col++)
                    {
                        if (chessBoard[row, col] == 'K')
                        {
                            int attacksKnights = Attacks(row, col, chessBoard);
                            if (attacksKnights > mostAttacks)
                            {
                                mostAttacks = attacksKnights;
                                mostRow = row;
                                mostCol = col;
                            }
                        }
                    }
                }
                if (mostAttacks==0)
                {
                    break;
                }
                chessBoard[mostRow, mostCol] = '0';
                removedKnights++;
                mostAttacks = 0;
            }

            Console.WriteLine(removedKnights);

        }

        static int Attacks(int row, int col, char[,] chessBoard)
        {
            int attacksKnights = 0;
            if (row - 2 >= 0 && col - 1 >= 0) //top left side
            {
                if (chessBoard[row - 2, col - 1] == 'K')
                {
                    attacksKnights++;
                }
            }
            if (row - 2 >= 0 && chessBoard.GetLength(1) > col + 1) //top right side
            {
                if (chessBoard[row - 2, col + 1] == 'K')
                {
                    attacksKnights++;
                }
            }
            if (row - 1 >= 0 && col - 2 >= 0)// horizontal left side up
            {
                if (chessBoard[row - 1, col - 2] == 'K')
                {
                    attacksKnights++;
                }
            }
            if (row + 1 <chessBoard.GetLength(0) && col - 2 >= 0)//horizontal left side down
            {
                if (chessBoard[row + 1, col - 2] == 'K')
                {
                    attacksKnights++;
                }
            }
            if (row - 1 >= 0 && chessBoard.GetLength(1) > col + 2)//horizontal right side up
            {
                if (chessBoard[row - 1, col + 2] == 'K')
                {
                    attacksKnights++;
                }
            }
            if (chessBoard.GetLength(0) > row + 1 && chessBoard.GetLength(1) > col + 2)// horizontal right side down
            {
                if (chessBoard[row + 1, col + 2] == 'K')
                {
                    attacksKnights++;
                }
            }
            if (chessBoard.GetLength(0) > row + 2 && col - 1 >= 0)//bottom left side
            {
                if (chessBoard[row + 2, col - 1] == 'K')
                {
                    attacksKnights++;
                }
            }
            if (chessBoard.GetLength(0) > row + 2 && chessBoard.GetLength(1) > col + 1)//bottom right side
            {
                if (chessBoard[row + 2, col + 1] == 'K')
                {
                    attacksKnights++;
                }
            }
            return attacksKnights;
        }
    }
}
