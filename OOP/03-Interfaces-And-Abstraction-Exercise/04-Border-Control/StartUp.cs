using System;
using System.Collections.Generic;

namespace _04_Border_Control
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //List<Citizens> citizens = new List<Citizens>();
            //List<Robots> robots = new List<Robots>();
            List<IIdentify> identify = new List<IIdentify>();
               
            string command;
            while ((command = Console.ReadLine())!="End")
            {
                //recieving information about citizen or robot who tries to enther the city in format: "{name} {age} {id}" for citizens and "{model} {id}" for robots. 
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                if (tokens.Length==3)
                {
                    int age = int.Parse(tokens[1]);
                    string id = tokens[2];
                    identify.Add(new Citizens(name, age, id));
                }
                else
                {
                    string id = tokens[1];
                    identify.Add(new Robots(name, id));
                }
            }

            string lastDigitID = Console.ReadLine();

            foreach (var citizen in identify)
            {
                citizen.ChechID(lastDigitID);
            }

           //foreach (var robot in robots)
           //{
           //    robot.ChechID(lastDigitID);
           //}
            //after end command you will receive a single number representing the last digits of fake ids, all citizens or robots whose Id ends with the specified digits must be detained.

            //The output of your program should consist of all detained Ids each on a separate line in the order of input.
        }
    }
}
