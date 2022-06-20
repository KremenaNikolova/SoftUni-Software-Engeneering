using System;
using System.Collections.Generic;
using System.Linq;

namespace _3_Merging_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstInput = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondInput = Console.ReadLine().Split().Select(int.Parse).ToList();

            int maxInputLenght = Math.Max(firstInput.Count, secondInput.Count);

            for (int i = 0; i < maxInputLenght; i++)
            {
                if (i >= firstInput.Count && secondInput.Count > firstInput.Count)
                {
                    for (int j = i; j < secondInput.Count; j++)
                    {
                        Console.Write(secondInput[j] + " ");
                    }
                    return;

                }
                if (i >= secondInput.Count && firstInput.Count > secondInput.Count)
                {
                    for (int j = i; j < firstInput.Count; j++)
                    {
                        Console.Write(firstInput[j] + " ");
                    }
                    return;
                }
                else
                {
                    Console.Write(firstInput[i] + " ");
                    Console.Write(secondInput[i] + " ");
                }

            }
        }
    }
}
