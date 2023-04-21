using Raiding.Models;
using System;

namespace Raiding
{
    public class HeroFactory
    {
        public static BaseHero GetHero(string name, string type)
        {
            BaseHero heroes = null;
            if (type == "Druid")
            {
                heroes=new Druid(name);
            }
            else if (type == "Paladin")
            {
                heroes=new Paladin(name);
            }
            else if (type == "Rogue")
            {
                heroes=new Rogue(name);
            }
            else if (type == "Warrior")
            {
                heroes=new Warrior(name);
            }
            else
            {
               throw new Exception("Invalid hero!");
            }
            return heroes;
        }


    }
}

