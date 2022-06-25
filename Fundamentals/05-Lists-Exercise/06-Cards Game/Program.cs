using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_Cards_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPlayer = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondPlayer = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (firstPlayer.Count > 0 && secondPlayer.Count > 0)
            {

                if (firstPlayer[0] > secondPlayer[0])
                {
                    firstPlayer.Add(firstPlayer[0]);
                    firstPlayer.Add(secondPlayer[0]);

                }
                else if (firstPlayer[0] < secondPlayer[0])
                {
                    secondPlayer.Add(secondPlayer[0]);
                    secondPlayer.Add(firstPlayer[0]);
                }
                firstPlayer.Remove(firstPlayer[0]);
                secondPlayer.Remove(secondPlayer[0]);

                if (firstPlayer.Count == 0)
                {
                    int sum = 0;
                    foreach (var number in secondPlayer)
                    {
                        sum += number;
                    }
                    Console.WriteLine($"Second player wins! Sum: {sum}");
                    break;
                }
                if (secondPlayer.Count == 0)
                {
                    int sum = 0;
                    foreach (var number in firstPlayer)
                    {
                        sum += number;
                    }
                    Console.WriteLine($"First player wins! Sum: {sum}");
                    break;
                }
            }

        }

    }
}
