using Birthday.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Birthday
{
    public class Citizen : IIdentify, IBirthdate, IID
    {
        public Citizen(string name, int age, string iD, string birthdate)
        {
            Name = name;
            Age = age;
            ID = iD;
            Birthdate = birthdate;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string ID { get; private set; }
        public string Birthdate { get; private set; }
        
        public int Food { get; private set; }

        public void BuyFood(string name)
        {
            if (name==Name)
            {
                Food += 10;
            }
        }
    }
}
