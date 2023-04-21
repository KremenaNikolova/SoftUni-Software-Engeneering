using System;

namespace Armory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] armory = new char[size, size];

            int rowPosition = 0;
            int colPosition = 0;

            int coints = 0;

            for (int row = 0; row < size; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    armory[row, col] = input[col];
                    if (armory[row,col]=='A')
                    {
                        rowPosition = row;
                        colPosition = col;
                        armory[row,col]='-';
                    }
                }
            }

            //on the random position will be swords with number. the number is their price
            //on the random position will be also mirrors 'M' and their count will be either 0 or 2
            // directions are "up", "down", "left", "right"

            //if army office is on sword he buy it for the price of the number
            //if he is on mirror position, he teleport to the other mirror position, and both of them disapear
            //If you guide the army officer out of the armory, he leaves with the swords that he has bought. 

            //In advance, you negotiate with the king, that he'll buy at least 65 gold coins worth of blades.

            //The program ends when the army officer buys blades for at least 65 gold coins, or you guide him out of the armory.

            while (coints<65)
            {
                string command = Console.ReadLine();
                if (command =="up")
                {
                    rowPosition--;
                    if (!isValidPositiong(rowPosition,colPosition,armory))
                    {
                        break;
                    }
                    MoveOn(ref rowPosition, ref colPosition, armory, ref coints);

                }
                else if (command=="down")
                {
                    rowPosition++;
                    if (!isValidPositiong(rowPosition, colPosition, armory))
                    {
                        break;
                    }
                    MoveOn(ref rowPosition, ref colPosition, armory, ref coints);
                }
                else if (command=="left")
                {
                    colPosition--;
                    if (!isValidPositiong(rowPosition, colPosition, armory))
                    {
                        break;
                    }
                    MoveOn(ref rowPosition, ref colPosition, armory, ref coints);
                }
                else if (command=="right")
                {
                    colPosition++;
                    if (!isValidPositiong(rowPosition, colPosition, armory))
                    {
                        break;
                    }
                    MoveOn(ref rowPosition, ref colPosition, armory, ref coints);
                }
            }

            if (isValidPositiong(rowPosition, colPosition, armory))
            {
                armory[rowPosition, colPosition] = 'A';
            }
            var outOfAmory = isValidPositiong(rowPosition, colPosition, armory) == true ? "Very nice swords, I will come back for more!" : "I do not need more swords!";

            Console.WriteLine(outOfAmory);
            Console.WriteLine($"The king paid {coints} gold coins.");

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(armory[row,col]);
                }
                Console.WriteLine();
            }
        }
        static bool isValidPositiong(int rowPosition,int colPosition, char[,] armory)
        {
            return rowPosition >= 0 && rowPosition < armory.GetLength(0)
                && colPosition >= 0 && colPosition < armory.GetLength(1);
        }
        static void MoveOn(ref int rowPosition, ref int colPosition, char[,] armory,ref int coints)
        {
            if (armory[rowPosition,colPosition]=='M')
            {
                armory[rowPosition, colPosition] = '-';
                for (int row = 0; row < armory.GetLength(0); row++)
                {
                    for (int col = 0; col < armory.GetLength(1); col++)
                    {
                        if (armory[row,col]=='M')
                        {
                            rowPosition = row;
                            colPosition = col;
                            armory[rowPosition,colPosition] = '-';
                        }
                    }
                }
            }
            else if (char.IsDigit(armory[rowPosition,colPosition]))
            {
                coints += int.Parse(armory[rowPosition, colPosition].ToString());
                armory[rowPosition,colPosition] = '-';
            }
        }
    }
}
