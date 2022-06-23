using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_Change_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();

            bool isEnd = false;

            while (isEnd == false)
            {
                string command = Console.ReadLine();
                string[] tokens = command.Split();
                if (tokens[0] == "end")
                {
                    isEnd = true;
                    break;
                }
                else if (tokens[0] == "Delete")
                {
                    int stringToInt = int.Parse(tokens[1]);
                    input.RemoveAll(number => number == stringToInt);
                }
                else if (tokens[0] == "Insert")
                {
                    int addNumber = int.Parse(tokens[1]);
                    int position = int.Parse(tokens[2]);
                    input.Insert(position, addNumber);
                }
            }
            Console.WriteLine(string.Join(" ", input));
        }
    }
}
