using System;
using System.Collections.Generic;

namespace _14_HeroesOfCodeAndLogicVII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfHeroes = int.Parse(Console.ReadLine());
            Dictionary <string, Hero> heroInformation = new Dictionary<string, Hero> ();

            for (int i = 0; i < numberOfHeroes; i++)
            {
                string[] heroes = Console.ReadLine().Split(" ");
                string name = heroes[0];
                Hero hero = new Hero(int.Parse(heroes[1]), int.Parse(heroes[2]));
                heroInformation.Add(name, hero);
            }

            string[] command = Console.ReadLine().Split(" - ", StringSplitOptions.RemoveEmptyEntries);
            while (command[0]!="End")
            {
                string action = command[0];
                switch (action)
                {
                    case "CastSpell":
                        CastSell(command[1], int.Parse(command[2]), command[3], heroInformation);
                        break;
                    case "TakeDamage":
                        TakeDamage(command[1], int.Parse(command[2]), command[3], heroInformation);
                        break;
                    case "Recharge":
                        Recharge(command[1], int.Parse(command[2]), heroInformation);
                        break;
                    case "Heal":
                        Heal(command[1], int.Parse(command[2]), heroInformation);
                        break;
                }

                command = Console.ReadLine().Split(" - ", StringSplitOptions.RemoveEmptyEntries);
            }
            foreach (var hero in heroInformation)
            {
                Console.WriteLine($"{hero.Key}");
                Console.WriteLine($"  HP: {hero.Value.HitPoints}");
                Console.WriteLine($"  MP: {hero.Value.ManaPoints}");
            }
        }

       
        private static void CastSell(string heroName, int mpNeeded, string spellName, Dictionary<string, Hero> heroInformation)
        {
            if (heroInformation[heroName].ManaPoints>=mpNeeded)
            {
                int mpLeft = heroInformation[heroName].ManaPoints - mpNeeded;
                heroInformation[heroName].ManaPoints=mpLeft;
                Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {mpLeft} MP!");
            }
            else
            {
                Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
            }
        }

        private static void TakeDamage(string heroName, int damage, string attacker, Dictionary<string, Hero> heroInformation)
        {
            if (heroInformation[heroName].HitPoints-damage>0)
            {
                int currHP = heroInformation[heroName].HitPoints - damage;
                heroInformation[heroName].HitPoints=currHP;
                Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {currHP} HP left!");
            }
            else
            {
                Console.WriteLine($"{heroName} has been killed by {attacker}!");
                heroInformation.Remove(heroName);
            }
        }

        private static void Recharge(string heroName, int amount, Dictionary<string, Hero> heroInformation)
        {
            int originalMP = heroInformation[heroName].ManaPoints;
            heroInformation[heroName].ManaPoints += amount;
            if (heroInformation[heroName].ManaPoints>200)
            {
                heroInformation[heroName].ManaPoints = 200;
                amount = 200 - originalMP;
            }
            Console.WriteLine($"{heroName} recharged for {amount} MP!");
        }
        private static void Heal(string heroName, int amount, Dictionary<string, Hero> heroInformation)
        {
            int originalHP = heroInformation[heroName].HitPoints;
            heroInformation[heroName].HitPoints += amount;
            if (heroInformation[heroName].HitPoints > 100)
            {
                heroInformation[heroName].HitPoints = 100;
                amount = 100 - originalHP;
            }
            Console.WriteLine($"{heroName} healed for {amount} HP!");
        }


        class Hero
        {
            public Hero(int hitPoints, int manaPoints)
            {
                //this.HeroName = heroName;
                this.HitPoints = hitPoints;
                this.ManaPoints = manaPoints;
            }
            //public string HeroName { get; set; }
            public int HitPoints { get; set; }
            public int ManaPoints { get; set; }
        }
        
    }
}
