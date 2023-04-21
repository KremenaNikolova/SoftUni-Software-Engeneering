using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _5ComparingObjects
{
    public class Person : IComparable<Person>
    {

        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        public int CompareTo(Person other)
        {
            if (Name != other.Name)
            {
                return Name.CompareTo(other.Name);
            }
            else if (Age != other.Age)
            {
                return Age.CompareTo(other.Age);
            }
            else if (Town != other.Town)
            {
                return Town.CompareTo(other.Town);
            }
            return 0;

        }
    }
}
