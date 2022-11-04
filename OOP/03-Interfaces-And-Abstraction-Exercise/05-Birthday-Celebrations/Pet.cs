using System;
using System.Collections.Generic;
using System.Text;

namespace Birthday
{
    public class Pet : IBirthdable
    {
        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }

        public string Name {get; private set;}

        public string Birthdate {get; private set;}

        public void BirthdateCheck(string date)
        {
            string[] birthdateSplit = Birthdate.Split("/", StringSplitOptions.RemoveEmptyEntries);
            string year = birthdateSplit[2];
            if (year == date)
            {
                Console.WriteLine(Birthdate);
            }
        }
    }
}
