using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_Moving_Target
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> sequenceOfTarget = Console.ReadLine().Split().Select(int.Parse).ToList();

            bool isEnd = false;

            while (isEnd!=true)
            {
                string command = Console.ReadLine();

                if (command=="End")
                {
                    isEnd = true;
                    break;
                }
                string[] tokens=command.Split();

                int index = int.Parse(tokens[1]);
                int power = int.Parse(tokens[2]);

                
                if (tokens[0]== "Shoot")
                {
                    if (index > sequenceOfTarget.Count - 1 || index<0)
                    {
                        continue;
                    }
                    sequenceOfTarget[index]-=power;
                    if (sequenceOfTarget[index] <=0)
                    {
                    sequenceOfTarget.RemoveAt(index);

                    }
                }
                else if (tokens[0]=="Add")
                {
                    if (index > sequenceOfTarget.Count - 1 || index<0)
                    {
                        Console.WriteLine("Invalid placement!");
                        continue;
                    }
                    sequenceOfTarget.Insert(index, power);
                }
                else if (tokens[0]=="Strike")
                {
                    if (index-power<0 || index+power>sequenceOfTarget.Count-1)
                    {
                        Console.WriteLine("Strike missed!");
                        continue;
                    }
                    else
                    {
                        sequenceOfTarget.RemoveRange(index-power, power*2+1);
                    }
                }
            }
            Console.WriteLine(string.Join("|", sequenceOfTarget));
        }
    }
}
