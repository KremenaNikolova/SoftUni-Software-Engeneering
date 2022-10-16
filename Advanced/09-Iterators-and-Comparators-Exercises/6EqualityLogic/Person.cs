using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _6EqualityLogic
{
    internal class Person : IComparable<Person>
    {
        private int personID;
        public string Name { get; set; }
        public int Age { get; set; }
        public int PersonID { get; set; }

        public int CompareTo(Person other)
        {
            if (Name.CompareTo(other.Name) != 0)
            {
                return Name.CompareTo(other.Name);
            }
            return Age.CompareTo(other.Age);
        }

        public override bool Equals(object obj)
        {
            Person person = obj as Person;
            if (person == null) return false;

            return  Name==person.Name && Age==person.Age;
        }
        public override int GetHashCode()
        {
            int hashCode = Name.GetHashCode() + Age.GetHashCode();
            return hashCode;
        }
    }
}
