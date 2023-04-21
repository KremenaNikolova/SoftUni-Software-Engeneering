using Birthday.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Birthday
{
    public class Rebel : IGroup, IIdentify
    {
        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Group { get; private set; }
        public int Food { get; private set; }

        public void BuyFood(string name)
        {
            if (name==Name)
            {
                Food += 5;
            }
        }
    }
}
