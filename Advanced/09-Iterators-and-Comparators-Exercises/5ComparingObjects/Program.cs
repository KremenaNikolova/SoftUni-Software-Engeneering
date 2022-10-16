using System;
using System.Collections.Generic;

namespace _5ComparingObjects
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> list = new List<Person>();
            string personInformation = Console.ReadLine();

            while (personInformation != "END")
            {
                string[] tokens = personInformation.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string town = tokens[2];
                Person person = new Person
                {
                    Name = name,
                    Age = age,
                    Town = town,
                };
                list.Add(person);

                personInformation = Console.ReadLine();
            }

            int indexOfPerson = int.Parse(Console.ReadLine());
            Person comparePerson = list[indexOfPerson-1];

            int matches = 0;
            int nomatches = 0;
            //"{count of matches} {number of not equal people} {total number of people}"
            foreach (var person in list)
            {
                if (person.CompareTo(comparePerson)==0)
                {
                    matches++;
                }
                else
                {
                    nomatches++;
                }
            }

            if (matches==1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{matches} {nomatches} {list.Count}");
            }


        }
    }
}
