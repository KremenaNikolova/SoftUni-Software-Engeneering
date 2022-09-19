using System;
using System.Collections.Generic;

namespace _10_Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenDuartion = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>();
            Queue<char> car = new Queue<char>();
            int carsPassed = 0;

            string command = Console.ReadLine();
            while (command!="END")
            {
                if (command!="green")
                {
                    string carType = command;
                    queue.Enqueue(carType);
                }
                else if(queue.Count > 0)
                {
                    string currCarr = queue.Dequeue();
                    char[] carr = currCarr.ToCharArray();
                    car = new Queue<char>(carr);
                    for (int duration = 0; duration < greenDuartion; duration++)
                    {
                        car.Dequeue();
                        if (car.Count == 0)
                        {
                            carsPassed++;
                            if (queue.Count>0 && duration + 1 != greenDuartion)
                            {
                                currCarr = queue.Dequeue();
                                carr = currCarr.ToCharArray();
                                car = new Queue<char>(carr);
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    if (car.Count>0)
                    {
                        for (int free = 0; free < freeWindowDuration; free++)
                        {
                            car.Dequeue();
                            if (car.Count==0)
                            {
                                carsPassed++;
                                break;
                            }
                        }
                        if (car.Count>0)
                        {
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{currCarr} was hit at {car.Peek()}.");
                            return;
                        }
                    }
                }

                command = Console.ReadLine();
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carsPassed} total cars passed the crossroads.");
        }
    }
}
