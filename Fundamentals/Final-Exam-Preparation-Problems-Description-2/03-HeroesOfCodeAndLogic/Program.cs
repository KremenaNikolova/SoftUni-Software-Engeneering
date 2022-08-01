using System;
using System.Collections.Generic;

namespace _03_Pirates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfHeroes = int.Parse(Console.ReadLine());
            Dictionary<string, List<int>> heroInformation = new Dictionary<string, List<int>>();

            for (int i = 0; i < numberOfHeroes; i++)
            {
                string[] heroInfo = Console.ReadLine().Split();
                string heroName = heroInfo[0];
                int heroHp = int.Parse(heroInfo[1]);
                int heroMp = int.Parse(heroInfo[2]);

                
                heroInformation.Add(heroName, new List<int> { heroHp, heroMp });

                //-	a hero can have a maximum of 100 HP and 200 MP
            }

            string[] command = Console.ReadLine().Split(" - ", StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "End")
            {
                string action = command[0];
                string heroName = command[1];

                switch (action)
                {
                    case "CastSpell":
                        CastSpell(heroName, int.Parse(command[2]), command[3], heroInformation);
                        break;
                    case "TakeDamage":
                        TakeDamage(heroName, int.Parse(command[2]), command[3], heroInformation);
                        break;
                    case "Recharge":
                        Recharge(heroName, int.Parse(command[2]), heroInformation);
                        break;
                    case "Heal":
                        Heal(heroName, int.Parse(command[2]), heroInformation);
                        break;
                }

                command = Console.ReadLine().Split(" - ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var hero in heroInformation)
            {
                Console.WriteLine(hero.Key);
                Console.WriteLine($"  HP: {hero.Value[0]}");
                Console.WriteLine($"  MP: {hero.Value[1]}");
            }
        }

        private static void CastSpell(string heroName, int mpNeeded, string spellName, Dictionary<string, List<int>> heroInformation)
        {
            if (heroInformation[heroName][1]>=mpNeeded)
            {
                heroInformation[heroName][1] -= mpNeeded;
                Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroInformation[heroName][1]} MP!");
                return;
            }
            Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
        }

        private static void TakeDamage(string heroName, int damage, string attacker, Dictionary<string, List<int>> heroInformation)
        {
            heroInformation[heroName][0] -= damage;
            if (heroInformation[heroName][0]>0)
            {
                Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroInformation[heroName][0]} HP left!");
                return;
            }
            Console.WriteLine($"{heroName} has been killed by {attacker}!");
            heroInformation.Remove(heroName);
        }

        private static void Recharge(string heroName, int amount, Dictionary<string, List<int>> heroInformation)
        {
            heroInformation[heroName][1] += amount;
            if (heroInformation[heroName][1]>200)
            {
                heroInformation[heroName][1] = 200;
            }
            Console.WriteLine($"{heroName} recharged for {amount} MP!");
        }

        private static void Heal(string heroName, int amount, Dictionary<string, List<int>> heroInformation)
        {
            heroInformation[heroName][0] += amount;
            if (heroInformation[heroName][0] > 100)
            {
                heroInformation[heroName][0] = 100;
            }
            Console.WriteLine($"{heroName} healed for {amount} HP!");
        }
    }
}
