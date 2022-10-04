//Use your Person class from the previous tasks. Create a class Family.
//The class should have a list of people, a method for adding members - void AddMember(Person member) and a method returning the oldest family member – Person GetOldestMember().
//Write a program that reads the names and ages of N people and adds them to the family.
//Then print the name and age of the oldest member.

using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Family familyMembers = new Family();
            int counter = int.Parse(Console.ReadLine());

            for (int i = 0; i < counter; i++)
            {
                string[] personInformation = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = personInformation[0];
                int age = int.Parse(personInformation[1]);

                Person person = new Person(name, age);
                familyMembers.AddMember(person);
            }

            Person oldest = familyMembers.GetOldestPerson();
            Console.WriteLine($"{oldest.Name} {oldest.Age}");

        }
    }
}
