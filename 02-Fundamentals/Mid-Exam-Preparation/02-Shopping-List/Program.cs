using System;
using System.Linq;

namespace _02_Shopping_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int waitingPassagers = int.Parse(Console.ReadLine());
            int[] wagons = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int maxCapacityPerWagon = 4;

            for (int i = 0; i < wagons.Length; i++)
            {
                if (wagons[i]<maxCapacityPerWagon)
                {
                    int leftSpaces = maxCapacityPerWagon - wagons[i];
                    if (leftSpaces==0)
                    {
                        continue;
                    }
                    else
                    {
                        if (waitingPassagers>=leftSpaces)
                        {
                            wagons[i] += leftSpaces;
                            waitingPassagers -= leftSpaces;
                        }
                        else
                        {
                            leftSpaces = waitingPassagers;
                            wagons[i] += leftSpaces;
                            waitingPassagers -= leftSpaces;
                        }
                        
                    }
                }
                if (waitingPassagers == 0)
                {
                    break;
                }
            }
            //Console.WriteLine(wagons.Sum());
            if (waitingPassagers==0 && wagons.Sum() < wagons.Length * maxCapacityPerWagon)
            {
                Console.WriteLine("The lift has empty spots!");
                Console.WriteLine(string.Join(" ", wagons));
            }
            else if (waitingPassagers>0 && wagons.Sum() >= wagons.Length * maxCapacityPerWagon)
            {
                Console.WriteLine($"There isn't enough space! {waitingPassagers} people in a queue!");
                Console.WriteLine(string.Join(" ", wagons));
            }
            else if (waitingPassagers==0 && wagons.Sum() == wagons.Length * maxCapacityPerWagon)
            {
                Console.WriteLine(string.Join(" ", wagons));
            }
        }
    }
}
