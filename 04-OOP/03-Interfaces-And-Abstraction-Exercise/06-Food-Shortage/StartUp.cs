using Birthday.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Birthday
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Citizen> citizens = new List<Citizen>();
            List<Rebel> rebels = new List<Rebel>();
            int peopleNums = int.Parse(Console.ReadLine());

            for (int i = 0; i < peopleNums; i++)
            {
                string[] information = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                if (information.Length==4)
                {
                    citizens.Add(new Citizen(information[0], int.Parse(information[1]), information[2], information[3]));
                }
                else
                {
                    rebels.Add(new Rebel(information[0], int.Parse(information[1]), information[2]));
                }
            }

            string name;
            while ((name=Console.ReadLine())!="End")
            {
                foreach (var citizen in citizens)
                {
                    citizen.BuyFood(name);
                }
                foreach (var rebel in rebels)
                {
                    rebel.BuyFood(name);
                }

                
            }
            int totalFood = (rebels.Select(x=>x.Food).Sum())+(citizens.Select(y=>y.Food).Sum()); 
            Console.WriteLine(totalFood);
        }
    }
}
