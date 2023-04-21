using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> persons;

        public Family()
        {
            persons = new List<Person>();
        }
        public List<Person> Persons { get { return persons; } set { persons = value; } }


        public void AddMember(Person member)
        {
            this.persons.Add(member);
        }

        public Person GetOldestPerson()
        {
            return this.persons
                .OrderByDescending(p => p.Age)
                .FirstOrDefault();
        }
    }
}
