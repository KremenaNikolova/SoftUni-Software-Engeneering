using System;
using System.Collections.Generic;

namespace _04_Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Students> studentInfo = new List<Students>();
            while (true)
            {
                string studentInformation = Console.ReadLine();
                string[] tokens = studentInformation.Split();

                Students newInformation = new Students();
                if (studentInformation == "end")
                {
                    break;
                }

                newInformation.FirstName = tokens[0];
                newInformation.LastName = tokens[1];
                newInformation.Age = tokens[2];
                newInformation.HomeTown = tokens[3];

                studentInfo.Add(newInformation);
            }

            string cityName = Console.ReadLine();

            foreach (Students item in studentInfo)
            {
                if (cityName == item.HomeTown)
                {
                    Console.WriteLine($"{item.FirstName} {item.LastName} is {item.Age} years old.");
                }
            }
        }
    }

    class Students
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string HomeTown { get; set; }
    }
}
