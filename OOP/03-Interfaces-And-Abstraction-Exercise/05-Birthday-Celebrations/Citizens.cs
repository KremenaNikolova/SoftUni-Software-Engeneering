using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04_Border_Control
{
    public class Citizens : IIdentify
    {
        public Citizens(string name, int age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Id { get; private set; }

        public void ChechID(string checkID)
        {
            string lastDigits = Id.Substring(Id.Length - checkID.Length);
            for (int i = 0; i < checkID.Length; i++)
            {
                if (lastDigits[i] != checkID[i])
                {
                    return;
                }
            }
            Console.WriteLine(Id);
        }
    }
}
