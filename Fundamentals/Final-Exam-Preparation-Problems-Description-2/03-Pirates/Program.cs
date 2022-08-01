using System;
using System.Collections.Generic;

namespace _03_Pirates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfHeroes = int.Parse(Console.ReadLine());
            Dictionary<string, int> heroAndHP = new Dictionary<string, int>();
            Dictionary<string, int> heroAndMP = new Dictionary<string, int>();

            for (int i = 0; i < numberOfHeroes; i++)
            {
                string[] heroInfo = Console.ReadLine().Split();
                string heroName = heroInfo[0];
                int heroHp = int.Parse(heroInfo[1]);
                int heroMp = int.Parse(heroInfo[2]);

                heroAndHP.Add(heroName, heroHp);
                heroAndMP.Add(heroName, heroMp);

                //-	a hero can have a maximum of 100 HP and 200 MP
            }

            string[] command = Console.ReadLine().Split(" – ");

            while (command[0]!="End")
            {
                string action = command[0];
                string heroName = command[1];
                if (action== "CastSpell")
                {
                    int mpNeed = int.Parse(command[2]);
                    string spellName = command[3];

                    if (mpNeed==heroAndHP.)
                    {

                    }
                }

                command = Console.ReadLine().Split(" – ");
            }
        }
    }
}
