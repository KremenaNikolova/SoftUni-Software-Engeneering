using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Bomb_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> randomNumbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> specialNumbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            int bombNumber = specialNumbers[0];
            int powerLenght = specialNumbers[1];
            for (int i = 0; i < randomNumbers.Count; i++)
            {
                if (bombNumber == randomNumbers[i])
                {
                    int target = randomNumbers[i];
                    if (target==bombNumber)
                    {
                        int start = Math.Max(0, i - powerLenght);
                        int end = Math.Min(randomNumbers.Count - 1, i + powerLenght);
                        for (int j = start; j <= end; j++)
                        {
                            randomNumbers[j] = 0;
                        }
                    }
                }
            }
            int sum = 0;
            foreach (var number in randomNumbers)
            {
                sum += number;
            }
            Console.WriteLine(sum);

        }
    }
}
