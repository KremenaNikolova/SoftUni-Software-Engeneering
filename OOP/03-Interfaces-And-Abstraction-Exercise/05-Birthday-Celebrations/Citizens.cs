using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Birthday
{
    public class Citizens : IIdentify ,IBirthdable
    {
        public Citizens(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            this.Birthdate = birthdate; 
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Id { get; private set; }

        public string Birthdate { get; private set; }

        public void BirthdateCheck(string date)
        {
            string[] birthdateSplit = Birthdate.Split("/", StringSplitOptions.RemoveEmptyEntries);
            string year = birthdateSplit[2];
            if (year==date)
            {
                Console.WriteLine(Birthdate);
            }
        }

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
