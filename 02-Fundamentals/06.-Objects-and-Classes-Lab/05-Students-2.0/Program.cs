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


                if (studentInformation == "end")
                {
                    break;
                }

                if (isStudentExisting(tokens[0], tokens[1], studentInfo))
                {
                    Students student = studentInfo.Find(student => student.FirstName == tokens[0] && student.LastName == tokens[1]);
                    student.Age = int.Parse(tokens[2]);
                    student.HomeTown = tokens[3];
                }
                else
                {
                    Students student = new Students(tokens[0], tokens[1], int.Parse(tokens[2]), tokens[3]);
                    studentInfo.Add(student);
                }
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

        private static bool isStudentExisting(string firstName, string lastName, List<Students> studentInfo)
        {
            foreach (Students student in studentInfo)
            {
                if (student.FirstName==firstName && student.LastName==lastName  )
                {
                    return true;
                }
            }
            return false;
        }
    }

    class Students
    {
        public Students (string firstName, string lastName, int age, string homeTown)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.HomeTown = homeTown;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }
    }
}
