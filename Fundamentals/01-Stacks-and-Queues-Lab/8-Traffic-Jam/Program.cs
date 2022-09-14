using System;
using System.Collections.Generic;

namespace _8_Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int carsCanPass = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>();

            string command = Console.ReadLine();
            int counter = 0;
            while (command!="end")
            {
                if (command == "green")
                {
                    for (int i = 0; i < carsCanPass; i++)
                    {
                        Console.WriteLine($"{queue.Dequeue()} passed!");
                        counter++;
                        if (queue.Count==0)
                        {
                            break;
                        }
                    }
                    command = Console.ReadLine();
                    continue;
                }
                queue.Enqueue(command);
                command = Console.ReadLine();
            }
            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
