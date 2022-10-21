using System;

namespace PawnWars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] chessBorad = new char[8, 8];

            int whiteRowPosition = 0;
            int whiteColumnPosition = 0;

            int blackRowPoisiton = 0;
            int blackColumnPoisiton = 0;

            for (int row = 0; row < 8; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < 8; col++)
                {
                    chessBorad[row, col] = input[col];
                    if (chessBorad[row, col] == 'w')
                    {
                        whiteRowPosition = row;
                        whiteColumnPosition = col;
                    }
                    else if (chessBorad[row, col] == 'b')
                    {
                        blackRowPoisiton = row;
                        blackColumnPoisiton = col;
                    }
                }
            }

            //White (w) moves from the 1st rank to the 8th rank direction.
            //Black (b) moves from 8th rank to the 1st rank direction.

            //Can capture another pawn only diagonally
            //When a pawn reaches the last rank, for white this is the 8th rank, and for black, this is the 1st rank, can be promoted to a queen.7
            //The first move is always made by the white pawn (w)

            for (int whitesTurn = 0; whitesTurn < 8; whitesTurn++)
            {
                if ((isValidPosition(whiteRowPosition-1,whiteColumnPosition-1,chessBorad) && chessBorad[whiteRowPosition - 1, whiteColumnPosition - 1] == 'b') || (isValidPosition(whiteRowPosition-1, whiteColumnPosition+1,chessBorad) && chessBorad[whiteRowPosition - 1, whiteColumnPosition + 1] == 'b'))
                {
                    whiteRowPosition = 8 - blackRowPoisiton;
                    whiteColumnPosition = blackColumnPoisiton;
                    Console.WriteLine($"Game over! White capture on {(char)(97 + whiteColumnPosition)}{whiteRowPosition}.");
                    return;
                }
                chessBorad[whiteRowPosition, whiteColumnPosition] = '-';
                whiteRowPosition--;
                chessBorad[whiteRowPosition, whiteColumnPosition] = 'w';
                if (whiteRowPosition == 0)
                {
                    Console.WriteLine($"Game over! White pawn is promoted to a queen at {(char)(97 + whiteColumnPosition)}8.");
                    return;
                }
                for (int blackTurn = 1; blackTurn > 0; blackTurn--)
                {
                    if ((isValidPosition(blackRowPoisiton+1,blackColumnPoisiton-1,chessBorad) && chessBorad[blackRowPoisiton + 1, blackColumnPoisiton - 1] == 'w') || (isValidPosition(blackRowPoisiton + 1, blackColumnPoisiton + 1, chessBorad) && chessBorad[blackRowPoisiton + 1, blackColumnPoisiton + 1] == 'w'))
                    {
                        blackRowPoisiton = whiteRowPosition;
                        blackColumnPoisiton = whiteColumnPosition;
                        Console.WriteLine($"Game over! Black capture on {(char)(97 + blackColumnPoisiton)}{8 - blackRowPoisiton}.");
                        return;
                    }
                    chessBorad[blackRowPoisiton, blackColumnPoisiton] = '-';
                    blackRowPoisiton++;
                    chessBorad[blackRowPoisiton, blackColumnPoisiton] = 'b';
                    if (blackRowPoisiton == 7)
                    {
                        Console.WriteLine($"Game over! Black pawn is promoted to a queen at {(char)(97 + blackColumnPoisiton)}1.");
                        return;
                    }
                }

            }


            static bool isValidPosition(int row, int col, char[,] chessBorad)
            {
                return row >= 0 && row < chessBorad.GetLength(0)
                    && col >= 0 && col < chessBorad.GetLength(1);
            }

        }
    }
}
