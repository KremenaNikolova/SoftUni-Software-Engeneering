using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private double price;
        private int destructionLevel;

        public Weapon(int desctructionLevel, double price)
        {
            Price = price;
            DestructionLevel = desctructionLevel;
        }
        
        public double Price 
        {
            get { return price; }
            private set
            {
                this.price = value;
            }
        }

        public int DestructionLevel
        {
            get { return destructionLevel; }
            private set
            {
                if (value<1)
                {
                    throw new ArgumentException(ExceptionMessages.TooLowDestructionLevel);
                }
                if (value>10)
                {
                    throw new ArgumentException(ExceptionMessages.TooHighDestructionLevel);
                }
                this.destructionLevel = value;
            }
        }
    }
            
}
