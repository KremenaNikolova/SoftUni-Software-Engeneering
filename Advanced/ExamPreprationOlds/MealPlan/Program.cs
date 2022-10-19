using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MealPlan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> meals = new Queue<string>(Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries));
            Stack<int> days = new Stack<int>(Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            int mealsCounter = 0;

            Dictionary<string, int> callories = new Dictionary<string, int>
            {
                {"salad",350 },
                {"soup", 490 },
                {"pasta", 680 },
                {"steak", 790 },
            };

            while (meals.Count>0 && days.Count>0)
            {
                int leftCallories = days.Pop();
                string meal = meals.Dequeue();
                mealsCounter++;
                leftCallories -= callories[meal];
                if (leftCallories>0)
                {
                    days.Push(leftCallories);
                }
                else if (leftCallories<0 && days.Count>0)
                {
                    leftCallories += days.Pop();
                    days.Push(leftCallories);
                }
            }

            if (meals.Count==0)
            {
                Console.WriteLine($"John had {mealsCounter} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", days)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {mealsCounter} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }


        }
    }
}
