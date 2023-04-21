using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int petrolPumps = int.Parse(Console.ReadLine());
            Queue<int[]> information = new Queue<int[]>();

            for (int i = 0; i < petrolPumps; i++)
            {
                information.Enqueue(Console.ReadLine().Split().Select(int.Parse).ToArray());
            }

            for (int index = 0; index < petrolPumps; index++)
            {
                int fuel = 0;
                foreach (var item in information)
                {
                    int fuelRecharge = item[0];
                    int distance = item[1];
                    fuel += fuelRecharge - distance;
                    if (fuel<0)
                    {
                        information.Enqueue(information.Dequeue());
                        fuel = 0;
                        break;
                    }
                }
                if (fuel>0)
                {
                    Console.WriteLine(index);
                    break;
                }
            }


        }
    }
}
