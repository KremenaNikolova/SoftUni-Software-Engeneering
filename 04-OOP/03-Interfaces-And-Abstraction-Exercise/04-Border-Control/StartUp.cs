﻿using System;
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

        }
    }
}
