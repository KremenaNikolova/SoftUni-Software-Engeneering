using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            List<IHero> knights = new List<IHero>();
            List<IHero> barbarians = new List<IHero>();

            foreach (var player in players)
            {
                if (player.GetType()== typeof(Knight))
                {
                    knights.Add(player);
                }
                else 
                {
                    barbarians.Add(player);
                }
            }
            int knightDeaths = 0;
            int barbariansDeaths = 0;

            while (knights.Count!=0 && barbarians.Count!=0)
            {
                foreach (var knight in knights)
                {
                    foreach (var barbarian in barbarians.Where(x=>x.IsAlive))
                    {
                        barbarian.TakeDamage(knight.Weapon.DoDamage());
                    }
                }
                barbariansDeaths+=barbarians.RemoveAll(x => x.Health <= 0);

                foreach (var barbarian in barbarians)
                {
                    foreach (var knight in knights.Where(x=>x.IsAlive))
                    {
                        knight.TakeDamage(barbarian.Weapon.DoDamage());
                    }
                }
                knightDeaths += knights.RemoveAll(x=> x.Health <= 0);
            }

            string winner = knights.Count > 0 ? $"The knights took {knightDeaths} casualties but won the battle." : $"The barbarians took {barbariansDeaths} casualties but won the battle.";

            return winner;

        }
    }
}
