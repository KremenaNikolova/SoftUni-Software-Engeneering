using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _05_Play_Catch
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] intergers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int exceptionsCounter = 0;

            while (exceptionsCounter != 3)
            {
                string[] arguments = Console.ReadLine().Split(" ");
                string command = arguments[0];
                try
                {
                    int index = int.Parse(arguments[1]);
                    if (command == "Replace")
                    {
                        int replaceNumber = int.Parse(arguments[2]);
                        Replace(index, replaceNumber, intergers);
                    }
                    else if (command == "Print")
                    {
                        int endIndex = int.Parse(arguments[2]);
                        Print(index, endIndex, intergers);
                    }
                    else if (command == "Show")
                    {
                        Show(index, intergers);
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    exceptionsCounter++;
                    Console.WriteLine("The index does not exist!");
                }
                catch (FormatException)
                {
                    exceptionsCounter++;
                    Console.WriteLine("The variable is not in the correct format!");
                }

            }
            Console.WriteLine(string.Join(", ", intergers));



            static int[] Replace(int index, int replaceNumber, int[] intergers)
            {
                intergers[index] = replaceNumber;
                return intergers;
            }

            static void Print(int startIndex, int endIndex, int[] intergers)
            {
                Queue<int> nums = new Queue<int>();
                for (int i = startIndex; i <= endIndex; i++)
                {
                    nums.Enqueue(intergers[i]);
                }
                Console.WriteLine(string.Join(", ", nums));
            }

            static void Show(int index, int[] intergers)
            {
                Console.WriteLine(intergers[index]);
            }
        }


    }
}
