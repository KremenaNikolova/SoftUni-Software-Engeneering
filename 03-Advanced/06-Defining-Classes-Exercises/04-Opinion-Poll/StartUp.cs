//Using the Person class, write a program that reads from the console N lines of personal information and then prints all people, whose age is more than 30 years, sorted in alphabetical order.

using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            List<Person> personList = new List<Person>();

            for (int i = 0; i < counter; i++)
            {
                string[] personInformation = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = personInformation[0];
                int age = int.Parse(personInformation[1]);
                if (age>30)
                {
                    personList.Add(new Person(name, age));
                }
            }
            personList = personList.OrderBy(p => p.Name).ToList();


            foreach (var person in personList)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
