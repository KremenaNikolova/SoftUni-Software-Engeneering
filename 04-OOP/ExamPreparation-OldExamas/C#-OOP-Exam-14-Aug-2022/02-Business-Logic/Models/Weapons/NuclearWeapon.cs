using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons
{
    public class NuclearWeapon : Weapon
    {
        public NuclearWeapon(int desctructionLevel) : base(desctructionLevel, 15)
        {
        }
    }
}
