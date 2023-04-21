using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Coffee_Lover
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split().ToList();
            int numberOfCommand = int.Parse(Console.ReadLine());

            while (numberOfCommand>0)
            {
                string command = Console.ReadLine();
                string[] tokens=command.Split();

                string action=tokens[0];

                if (action=="Include")
                {
                    input.Add(tokens[1]);
                }
                else if (action=="Remove")
                {
                    int coffees = int.Parse(tokens[2]);
                    if (coffees > input.Count)
                    {
                        continue;
                    }
                    else if (tokens[1]=="first")
                    {
                        for (int i = 0; i < coffees; i++)
                        {
                            input.Remove(input[0]);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < coffees; i++)
                        {
                            input.Remove(input[input.Count - 1]);
                        } 
                    }
                }
                else if (action=="Prefer")
                {
                    int firstIndex = int.Parse(tokens[1]);
                    int secondIndex = int.Parse(tokens[2]);
                    if (firstIndex<input.Count && secondIndex<input.Count)
                    {
                        string saveTheIndex = input[secondIndex];
                        input[secondIndex] = input[firstIndex];
                        input[firstIndex] = saveTheIndex;
                    }

                }
                else if (action=="Reverse")
                {
                    input.Reverse();
                }
                numberOfCommand--;
            }
            Console.WriteLine("Coffees:");
            Console.WriteLine(string.Join(" ", input));

        }
    }
}
