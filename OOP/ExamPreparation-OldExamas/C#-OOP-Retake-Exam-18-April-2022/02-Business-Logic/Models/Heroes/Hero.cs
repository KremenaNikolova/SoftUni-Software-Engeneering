using Heroes.Models.Contracts;
using Heroes.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Heroes.Models.Heroes
{
    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private IWeapon weapons;

        public Hero(string name, int health, int armour)
        {
            Name = name;
            Health = health;
            Armour = armour;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hero name cannot be null or empty.");
                }
                name = value;
            }
        }

        public int Health
        {
            get => health;
            private set
            {
                if (value<0)
                {
                    throw new ArgumentException("Hero health cannot be below 0.");
                }
                health = value;
            }
        }

        public int Armour
        {
            get => armour;
            private set
            {
                if (value<0)
                {
                    throw new ArgumentException("Hero armour cannot be below 0.");
                }
                armour = value;
            }
        }

        public IWeapon Weapon
        {
            get => weapons;
            private set
            {
                if (value==null)
                {
                    throw new ArgumentException("Hero armour cannot be below 0.");
                }
                weapons= value;
            }
        }

        public bool IsAlive
        {
            get 
            {
                if (health<0)
                {
                    return false;
                }
                return true;
            }

        }

        public void AddWeapon(IWeapon weapon)
        {
            this.weapons=weapon;
        }

        public void TakeDamage(int points)
        {
            armour-=points;
            if (armour<0)
            {
                int LeftPoints = Math.Abs(armour);
                armour = 0;
                health-= LeftPoints;
            }
        }
    }
}
