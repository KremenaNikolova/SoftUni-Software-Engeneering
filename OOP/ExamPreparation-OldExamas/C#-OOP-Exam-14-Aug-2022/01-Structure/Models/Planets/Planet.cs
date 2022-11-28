using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public abstract class Planet : IPlanet
    {
        private string name;
        private double budget;
        private double militaryPower;

        private UnitRepository units;
        private WeaponRepository weps;

        protected Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;

            units= new UnitRepository();
            weps=new WeaponRepository();

        }

        public string Name 
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }
                name = value;
            }
        }

        public double Budget
        {
            get { return budget; }
            set
            {
                if (value<0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }
                budget = value;
            }
        }

        public double MilitaryPower => CalculateMilitaryPower();

        public IReadOnlyCollection<IMilitaryUnit> Army => units.Models;

        public IReadOnlyCollection<IWeapon> Weapons => weps.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            units.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weps.AddItem(weapon);
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Planet: {name}");
            sb.AppendLine($"--Budget: {budget}");
            sb.AppendLine($"--Forces: {string. Join(", ", Army.GetType().Name)}");
            sb.AppendLine($"--Combat equipment: {string.Join(", ", Weapons.GetType().Name)}");
            sb.AppendLine($"--Military Power: {militaryPower}");

            return sb.ToString().TrimEnd();

        }

        public void Profit(double amount)
        {
            Budget += amount;
        }

        public void Spend(double amount)
        {
            if (Budget<amount)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }
            Budget-= amount;

        }

        public void TrainArmy()
        {
            foreach (var unit in Army)
            {
                unit.IncreaseEndurance();
            }   
        }

        public double CalculateMilitaryPower()
        {
            double totalAmount = Army.Select(x=>x.EnduranceLevel).Sum() + Weapons.Select(x=>x.DestructionLevel).Sum();

            if (Army.Any(x=>x.GetType().Name== "AnonymousImpactUnit"))
            {
                totalAmount += totalAmount * 0.3;
            }
            else if(Army.Any(x=>x.GetType().Name== "NuclearWeapon "))
            {
                totalAmount += totalAmount * 0.45;
            }

            return Math.Round(totalAmount, 3);
        }
    }
}
