using System;
using System.Collections.Generic;

namespace Birthday
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthdable> birthdates = new List<IBirthdable>();
            List<Robots> robots = new List<Robots>();   
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                //"Citizen <name> <age> <id> <birthdate>" for Citizen, "Robot <model> <id>" for Robot or "Pet <name> <birthdate" for Pet.

                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[1];
                if (tokens[0] == "Citizen")
                {
                    int age = int.Parse(tokens[2]);
                    string id = tokens[3];
                    string birthdate = tokens[4];
                    birthdates.Add(new Citizens(name, age, id, birthdate));
                }
                else if (tokens[0]=="Robot")
                {
                    string id = tokens[2];
                    robots.Add(new Robots(name, id));
                }
                else if (tokens[0]=="Pet")
                {
                    string birthdate = tokens[2];
                    birthdates.Add(new Pet(name, birthdate));
                }


            }

            string specificYear = Console.ReadLine();
            //print all birthdates (of both Citizen and Pet) in that year in the format day/month/year in the order of input.

            foreach (var alien in birthdates)
            {
                alien.BirthdateCheck(specificYear);
            }
        }
    }
}
