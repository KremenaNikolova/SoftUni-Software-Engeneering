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

            for (int i = 0; i < counter; i++)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                if (type == "Druid")
                {
                    heroes.Add(new Druid(name));
                }
                else if (type =="Paladin")
                {
                    heroes.Add(new Paladin(name));
                }
                else if (type=="Rogue")
                {
                    heroes.Add(new Rogue(name));
                }
                else if (type == "Warrior")
                {
                    heroes.Add(new Warrior(name));
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
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
