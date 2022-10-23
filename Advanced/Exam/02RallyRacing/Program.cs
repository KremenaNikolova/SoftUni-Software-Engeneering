using System;
using System.Linq;

namespace _02RallyRacing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string racingNumber = Console.ReadLine();
            char[,] raceRoute = new char[size, size];

            int rowCar = 0;
            int colCar = 0;
            int km = 0;


            for (int row = 0; row < size; row++)
            {
                char[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    raceRoute[row, col] = input[col];
                }
            }

            //'T' is tunnel, if car go on it he teleport to the other 'T';
            //'F' is finish line //all other position will be market will '.';
            //every route is 10km, 'T' is 30km

            string command = Console.ReadLine();
            while (command!="End")
            {
                if (command=="up")
                {
                    rowCar--;
                    MoveOn(ref rowCar, ref colCar, raceRoute, ref km);
                    if (raceRoute[rowCar, colCar] == 'F')
                    {
                        break;
                    }
                }
                else if (command=="down")
                {
                    rowCar++;
                    MoveOn(ref rowCar, ref colCar, raceRoute, ref km);
                    if (raceRoute[rowCar, colCar] == 'F')
                    {
                        break;
                    }
                }
                else if (command=="left")
                {
                    colCar--;
                    MoveOn(ref rowCar, ref colCar, raceRoute, ref km);
                    if (raceRoute[rowCar, colCar] == 'F')
                    {
                        break;
                    }
                }
                else if (command=="right")
                {
                    colCar++;
                    MoveOn(ref rowCar, ref colCar, raceRoute, ref km);
                    if (raceRoute[rowCar, colCar] == 'F')
                    {
                        break;
                    }
                }
                command = Console.ReadLine();
            }

            if (raceRoute[rowCar,colCar]=='F')
            {
                Console.WriteLine($"Racing car {racingNumber} finished the stage!");
            }
            else if (command=="End")
            {
                Console.WriteLine($"Racing car {racingNumber} DNF.");
            }

            Console.WriteLine($"Distance covered {km} km.");

            raceRoute[rowCar, colCar] = 'C';

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(raceRoute[row,col]);
                }
                Console.WriteLine();
            }




            static void MoveOn(ref int row,ref int col, char[,] raceRoute, ref int km)
            {
                km += 10;
                if (raceRoute[row,col]=='T')
                {
                    km += 20;
                    raceRoute[row, col] = '.';
                    for (int i = 0; i < raceRoute.GetLength(0); i++)
                    {
                        for (int j = 0; j < raceRoute.GetLength(1); j++)
                        {
                            if (raceRoute[i,j]=='T')
                            {
                                row = i;
                                col = j;
                                raceRoute[row, col] = '.';
                            }
                        }
                    }
                }
            }
        }
    }
}
