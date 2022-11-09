using Raiding.Models;
using System;
using System.Collections.Generic;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            List<BaseHero> heroes = new List<BaseHero>();
         
            while (heroes.Count!=counter)
            {
                try
                {
                    string name = Console.ReadLine();
                    string type = Console.ReadLine();

                    heroes.Add(HeroFactory.GetHero(name, type));
                }
                catch (Exception exc)
                {

                    Console.WriteLine(exc.Message);
                }
            }
            int bossPower = int.Parse(Console.ReadLine());
            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
                bossPower -= hero.Power;
            }

            if (bossPower>0)
            {
                Console.WriteLine("Defeat...");
            }
            else
            {
                Console.WriteLine("Victory!");
            }
        }
    }
}
