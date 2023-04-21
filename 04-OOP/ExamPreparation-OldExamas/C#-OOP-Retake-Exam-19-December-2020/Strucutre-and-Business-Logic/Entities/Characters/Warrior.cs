using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker
    {
        //The Warrior class always has 100 Base Health, 50 Base Armor, 40 Ability Points, and a Satchel as a bag.
        private const double HEALTH = 100;
        private const double ARMOR = 50;
        private const double ABILITY_POINTS = 40;

        public Warrior(string name) : base(name, HEALTH, ARMOR, ABILITY_POINTS, new Satchel())
        {
        }

        public void Attack(Character character)
        {
            if (this == character)
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
            }
            this.EnsureAlive();
            character.EnsureAlive();
            character.TakeDamage(this.AbilityPoints);
        }
    }
}

