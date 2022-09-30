//Write a program that receives an integer N on the first line. On the next N lines, read pairs of "[name], [age]".
//Then read three lines:
//•	Condition - "younger"(<) or "older"(>=)
//•	Age threshold - integer
//•	Format - "name", "age" or "name age"
//Depending on the condition, print the correct pairs in the correct format.
//Don't use the built-in functionality from .NET.
//Create your own methods.


using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_Filter_By_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int counter = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < counter; i++)
            {
                string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                int age = int.Parse(input[1]);
                
                Person person = new Person(name, age);
                people.Add(person);
            }

            string condition = Console.ReadLine();
            int ageThreshold = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<Person, bool> filter = (x) => true; 
            if (condition=="younger")
            {
                filter = x => x.Age < ageThreshold;
            }
            else
            {
                filter = x => x.Age >= ageThreshold;
            }

            Action<Person> printer = Printer(format);
            PrintFilteredPeople(people, filter, printer);
           

        }

        private static void PrintFilteredPeople(List<Person> people, Func<Person, bool> filter, Action<Person> printer)
        {
            List<Person> filteredPeople = people.Where(x => filter(x)).ToList();
            foreach (var person in filteredPeople)
            {
                printer(person);
            }
        }

        private static Action<Person> Printer(string format)
        {
            switch (format)
            {
                case "name":
                    return x => Console.WriteLine(x.Name);
                case "age":
                    return x => Console.WriteLine(x.Age);
                case "name age":
                    return x => Console.WriteLine(x.Name + " - " + x.Age);
                default:
                    return null;
            }
        }

        public class Person
        {
            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }
            public string Name { get; set; }
            public int Age { get; set; }
        }

    }
}
