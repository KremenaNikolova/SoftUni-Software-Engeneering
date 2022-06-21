using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_List_Manipulation_Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();
            bool isEnd = false;

            while (isEnd==false)
            {
                string command = Console.ReadLine();
                if (command=="end")
                {
                    isEnd = true;
                    break;
                }
                string[] tokens = command.Split();

                switch (tokens[0])
                {
                    case "Add":
                        int addNumber=int.Parse(tokens[1]);
                        input.Add(addNumber);
                        break;
                    case "Remove":
                        int removeNumber = int.Parse(tokens[1]);
                        input.Remove(removeNumber);
                        break;
                    case "RemoveAt":
                        int removeAtIndex = int.Parse(tokens[1]);
                        input.RemoveAt(removeAtIndex);
                        break;
                    case "Insert":
                        int insertNumber = int.Parse(tokens[1]);
                        int indexOfTheNumber = int.Parse(tokens[2]);
                        input.Insert(indexOfTheNumber, insertNumber);
                        break;
                }
            }
            Console.WriteLine(string.Join(" ", input));
        }
    }
}
