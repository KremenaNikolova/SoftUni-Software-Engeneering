using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_Order_by_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Information> informationPersons = new List<Information>();

            while (true)
            {
                string[] personInformation = Console.ReadLine().Split();

                string name = personInformation[0];
                if (name=="End")
                {
                    break;
                }
                string id = personInformation[1];
                int age = int.Parse(personInformation[2]);

                if (isIdExisting(id, informationPersons))
                {
                    Information information = informationPersons.Find(information => information.Name == name && information.ID == id && information.Age == age);
                }
                else
                {
                    Information information = new Information(name, id, age);
                    informationPersons.Add(information);
                }

            }
            
            var sorted = informationPersons.OrderBy(row => row.Age).ToList();
            foreach (var item in sorted)
            {
                Console.WriteLine($"{item.Name} with ID: {item.ID} is {item.Age} years old.");
            }
        }

        private static bool isIdExisting(string id, List<Information> informationPersons)
        {
            foreach (Information ids in informationPersons)
            {
                if (ids.ID==id)
                {
                    return true;
                }
            }
            return false;
        }
    }
    
    public class Information
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }

       public Information(string name, string iD, int age)
       {
           Name = name;
           ID = iD;
           Age = age;
       }
    }
}
