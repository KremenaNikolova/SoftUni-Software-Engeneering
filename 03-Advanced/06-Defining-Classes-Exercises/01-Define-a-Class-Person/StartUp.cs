//Define a class Person with private fields for name and age and public properties Name and Age.

using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            person.Name = name;
            person.Age = age;

            Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
        }
    }
}
