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
    public class Planet : IPlanet
    {
        private string name;
        private double budget;

        private IRepository<IMilitaryUnit> units;
        private IRepository<IWeapon> weps;

        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;

            units = new UnitRepository();
            weps = new WeaponRepository();

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
            private set
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

            sb.AppendLine($"Planet: {Name}");
            sb.AppendLine($"--Budget: {Budget} billion QUID");
            sb.AppendLine(units.Models.Any() ? $"--Forces: {string.Join(", ", Army.Select(x=>x.GetType().Name))}" : "--Forces: No units");
            sb.AppendLine(weps.Models.Any() ? $"--Combat equipment: {string.Join(", ", Weapons.Select(x=>x.GetType().Name))}" : "--Combat equipment: No weapons");
            sb.AppendLine($"--Military Power: {MilitaryPower}");

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
            double totalAmount = units.Models.Sum(x=>x.EnduranceLevel) + weps.Models.Sum(x=>x.DestructionLevel);

            if (units.Models.Any(x=>x.GetType().Name== "AnonymousImpactUnit"))
            {
                totalAmount += totalAmount*0.3;
            }
            else if(weps.Models.Any(x=>x.GetType().Name== "NuclearWeapon"))
            {
                totalAmount += totalAmount*0.45;
            }

            return Math.Round(totalAmount, 3);
        }
    }
}
