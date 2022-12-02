using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Map;
using Heroes.Models.Weapons;
using Heroes.Repositories;
using Heroes.Repositories.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace _02_Business_Logic.Core
{
    public class Controller : IController
    {
        private IRepository<IHero> heroes;
        private IRepository<IWeapon> weapons;

        public Controller()
        {
            heroes = new HeroRepository();
            weapons = new WeaponRepository();
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            if (!heroes.Models.Any(x=>x.Name==heroName))
            {
                throw new InvalidOperationException($"Hero {heroName} does not exist.");
            }
            if (!weapons.Models.Any(x=>x.Name==weaponName))
            {
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");
            }
            
            var hero = heroes.FindByName(heroName);
            var weapon = weapons.FindByName(weaponName);

            if (hero.Weapon!=null)
            {
                throw new InvalidOperationException($"Hero {heroName} is well-armed.");
            }

            hero.AddWeapon(weapon);
            weapons.Remove(weapon);

            string output = $"Hero {heroName} can participate in battle using a {weapon.GetType().Name.ToLower()}.";
            return output;
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            if (heroes.Models.Any(x => x.Name == name))
            {
                throw new InvalidOperationException($"The hero {name} already exists.");
            }

            IHero hero;
            switch (type)
            {
                case "Knight": hero = new Knight(name, health, armour); break;
                case "Barbarian": hero = new Barbarian(name, health, armour);  break;
                default: throw new InvalidOperationException("Invalid hero type.");
            }

            heroes.Add(hero);
            string output = hero.GetType() == typeof(Knight) ? 
                $"Successfully added Sir {name} to the collection." : 
                $"Successfully added Barbarian {name} to the collection.";

            return output;
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            if (weapons.Models.Any(x=>x.Name==name))
            {
                throw new InvalidOperationException($"The weapon {name} already exists.");

            }

            IWeapon weapon;
            switch (type) 
            {
                case "Claymore": weapon = new Claymore(name, durability); break;
                case "Mace": weapon = new Mace(name, durability); break;
                default: throw new InvalidOperationException("Invalid weapon type.");
            }

            weapons.Add(weapon);
            string output = $"A {type.ToLower()} {name} is added to the collection.";

            return output;
        }

        public string HeroReport()
        {
            StringBuilder sb = new StringBuilder();
            
            foreach (var hero in heroes.Models.OrderBy(x=>x.GetType().Name).ThenByDescending(x=>x.Health).ThenBy(x=>x.Name))
            {
                sb.AppendLine($"{hero.GetType().Name}: {hero.Name}");
                sb.AppendLine($"--Health: { hero.Health }");
                sb.AppendLine($"--Armour: { hero.Armour }");
                sb.AppendLine(hero.Weapon != null ? $"--Weapon: {hero.Weapon.Name}" : "--Weapon: Unarmed");
            }

            return sb.ToString().TrimEnd();
        }

        public string StartBattle()
        {
            Map map = new Map();
            ICollection<IHero> battleHeroes = heroes.Models.Where(x=>x.IsAlive && x.Weapon!=null).ToList();
            return map.Fight(battleHeroes);
        }
    }
}
