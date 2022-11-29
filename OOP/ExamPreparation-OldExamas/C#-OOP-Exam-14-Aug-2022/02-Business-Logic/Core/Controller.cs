using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private IRepository<IPlanet> planets;

        public Controller()
        {
            planets = new PlanetRepository();
        }
        public string AddUnit(string unitTypeName, string planetName)
        {
            var planet = planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            if (unitTypeName != "AnonymousImpactUnit" && unitTypeName != "SpaceForces" && unitTypeName != "StormTroopers")
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }
            if (planet.Army.Any(x => x.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }
            IMilitaryUnit newUnit = CreatNewUnit(unitTypeName);
            planet.Spend(newUnit.Cost);
            planet.AddUnit(newUnit);

            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        private IMilitaryUnit CreatNewUnit(string unitTypeName)
        {
            IMilitaryUnit militaryUnit = null;
            switch (unitTypeName)
            {
                case "AnonymousImpactUnit": militaryUnit = new AnonymousImpactUnit(); break;
                case "SpaceForces": militaryUnit = new SpaceForces(); break;
                case "StormTroopers": militaryUnit = new StormTroopers(); break;
            }

            return militaryUnit;
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            var planet = planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            if (planet.Weapons.Any(x => x.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }
            if (weaponTypeName != "BioChemicalWeapon" && weaponTypeName != "NuclearWeapon" && weaponTypeName != "SpaceMissiles")
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }

            IWeapon weapons = CreateNewWeapon(weaponTypeName, destructionLevel);
            planet.Spend(weapons.Price);
            planet.AddWeapon(weapons);
            

            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        private IWeapon CreateNewWeapon(string weaponTypeName, int destructionLevel)
        {
            IWeapon weps = null;

            switch (weaponTypeName)
            {
                case "BioChemicalWeapon": weps = new BioChemicalWeapon(destructionLevel); break;
                case "NuclearWeapon": weps = new NuclearWeapon(destructionLevel); break;
                case "SpaceMissiles": weps = new SpaceMissiles(destructionLevel); break;
            }

            return weps;
        }

        public string CreatePlanet(string name, double budget)
        {
            if (planets.Models.Any(x => x.Name == name))
            {
                return string.Format(OutputMessages.ExistingPlanet, name);
            }
            else
            {
                planets.AddItem(new Planet(name, budget));
                return string.Format(OutputMessages.NewPlanet, name);
            }
        }

        public string ForcesReport()
        {
            
            StringBuilder sb  = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");
            foreach (var planet in planets.Models.OrderByDescending(x => x.MilitaryPower).ThenBy(x => x.Name))
            {
                sb.AppendLine($"{planet.PlanetInfo()}");
            }

            return sb.ToString().TrimEnd();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            var planet1 = planets.FindByName(planetOne);
            var planet2 = planets.FindByName(planetTwo);

            bool planetOneHasNuclearWeapon = planet1.Weapons.Any(x => x.GetType().Name == "NuclearWeapon");
            bool planetTwoHasNuclearWeapon = planet2.Weapons.Any(x => x.GetType().Name == "NuclearWeapon");

            if (planet1.MilitaryPower == planet2.MilitaryPower)
            {
                if (!planetOneHasNuclearWeapon && !planetTwoHasNuclearWeapon)
                {
                    return NoWinner(planet1, planet2);
                }
                if (planetOneHasNuclearWeapon && planetTwoHasNuclearWeapon)
                {
                    return NoWinner(planet1, planet2);
                }
                if (planetOneHasNuclearWeapon)
                {
                    return Winner(planet1, planet2);
                }
                if (planetTwoHasNuclearWeapon)
                {
                    return Winner(planet2, planet1);
                }
            }
            else
            {
                if (planet1.MilitaryPower>planet2.MilitaryPower)
                {
                    return Winner(planet1, planet2);
                }
                else
                {
                    return Winner(planet2, planet1);
                }
            }
            return null;
        }

        private string Winner(IPlanet planet1, IPlanet planet2)
        {
            planet1.Spend(planet1.Budget / 2);
            double defenderHaldBudged = planet2.Budget / 2;
            planet1.Profit(defenderHaldBudged);
            double allArmyCost = planet2.Army.Sum(x => x.Cost);
            double allWeaponsCost = planet2.Weapons.Sum(x => x.Price);

            planet1.Profit(allArmyCost + allWeaponsCost);

            planets.RemoveItem(planet2.Name);

            return string.Format(OutputMessages.WinnigTheWar, planet1.Name, planet2.Name);

        }

        private string NoWinner(IPlanet planet1, IPlanet planet2)
        {
            planet1.Spend(planet1.Budget / 2);
            planet2.Spend(planet2.Budget / 2);

            return OutputMessages.NoWinner;
        }

        public string SpecializeForces(string planetName)
            {
                var planet = planets.FindByName(planetName);

                if (planet == null)
                {
                    throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
                }
                if (!planet.Army.Any())
                {
                    throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
                }
                planet.Spend(1.25);
                planet.TrainArmy();

                return string.Format(OutputMessages.ForcesUpgraded, planetName);
            }
        }
    }

