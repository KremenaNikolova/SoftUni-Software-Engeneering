using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons
{
    public class SpaceMissiles : Weapon
    {
        public SpaceMissiles(int desctructionLevel) : base(desctructionLevel, 8.75)
        {
        }
    }
}
