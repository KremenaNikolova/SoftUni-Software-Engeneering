using System;
using System.Collections.Generic;

namespace _6EqualityLogic
{
    public class Program
    {
        static void Main(string[] args)
        {
            HashSet<Person> hashSet = new HashSet<Person>();
            SortedSet<Person> sortedSet = new SortedSet<Person>();

            int inputLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputLines; i++)
            {
                string[] personInformation = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = personInformation[0];
                int age = int.Parse(personInformation[1]);

                Person person = new Person
                {
                    Name = name,
                    Age = age,
                };
                hashSet.Add(person);
                sortedSet.Add(person);
            }

            Console.WriteLine(hashSet.Count);
            Console.WriteLine(sortedSet.Count);
        }
    }
}
