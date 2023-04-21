using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Person
    {
        private string name;
        private int age;
        public Person()
        {
            Name = this.name = "No name";
            Age = this.age = 1;
        }
        public Person(int age) : this()
        {
            this.age = age;
        }
        public Person( string name, int age) : this(age)
        {
            this.name = name;
            this.age = age;
        }

        public string Name { get { return name; } set { name = value; } }
        public int Age { get { return age; } set { age = value; } }

        public void AddMember(string name, int age)
        {

        }

    }
}
