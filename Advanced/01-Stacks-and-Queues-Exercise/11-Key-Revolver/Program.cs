using System;
using System.Collections.Generic;
using System.Linq;

namespace _11_Key_Revolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int eachBulletPrice = int.Parse(Console.ReadLine());
            int sizeGunBarrel = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> bulletsStack = new Stack<int>(bullets);
            int[] locks = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> locksQueue = new Queue<int>(locks);
            int allMoney = int.Parse(Console.ReadLine());

            int bulletsCounter = 0;
            while (locksQueue.Count > 0)
            {
                bulletsCounter++;
                int currLock = locksQueue.Peek();
                if (currLock >= bulletsStack.Pop())
                {
                    Console.WriteLine("Bang!");
                    locksQueue.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                if (bulletsCounter % sizeGunBarrel == 0)
                {
                    if (bulletsStack.Count == 0)
                    {
                        Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
                        return;
                    }
                    else if (locksQueue.Count == 0)
                    {
                        Console.WriteLine("Reloading!");
                        Console.WriteLine($"{bulletsStack.Count} bullets left. Earned ${allMoney -= bulletsCounter * eachBulletPrice}");
                        return;
                    }
                    Console.WriteLine("Reloading!");

                }
            }
            Console.WriteLine($"{bulletsCounter} bullets left. Earned ${allMoney}");

        }
    }
}
