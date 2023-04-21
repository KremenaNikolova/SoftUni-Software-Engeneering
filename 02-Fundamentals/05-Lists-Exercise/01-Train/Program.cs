using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> passangersPerWagon = Console.ReadLine().Split().Select(int.Parse).ToList();
            int maxCapacity = int.Parse(Console.ReadLine());

            while (true)
            {
                string addCommand = Console.ReadLine();
                string[] tokens = addCommand.Split();
                if (tokens[0] == "end")
                {
                    break;
                }
                else if (tokens[0] == "Add")
                {
                    passangersPerWagon.Add(int.Parse(tokens[1]));
                }
                else
                {
                    int needPlaces = int.Parse(tokens[0]);
                    for (int i = 0; i < passangersPerWagon.Count; i++)
                    {
                        if (passangersPerWagon[i]+needPlaces<=maxCapacity || passangersPerWagon[i]<=0)
                        {
                            passangersPerWagon[i] += needPlaces;
                            break;
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(" ", passangersPerWagon));
        }
    }
}
