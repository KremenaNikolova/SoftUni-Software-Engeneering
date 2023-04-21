using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Priest : Character, IHealer
    {
        //The Priest class always has 50 Base Health, 25 Base Armor, 40 Ability Points, and a Backpack as a bag.
        private const double HEALTH = 50;
        private const double ARMOR = 25;
        private const double ABILITY_POINTS = 40;
        public Priest(string name) : base(name, HEALTH, ARMOR, ABILITY_POINTS, new Backpack())
        {
        }

        public void Heal(Character character)
        {
            EnsureAlive();
            character.EnsureAlive();
            character.Health += this.AbilityPoints;
        }
    }
}
