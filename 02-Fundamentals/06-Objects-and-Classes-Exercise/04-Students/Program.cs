using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();

            for (int i = 0; i < numberOfStudents; i++)
            {
                string[] studentInformation = Console.ReadLine().Split();
               
                string firstName = studentInformation[0];
                string lastName = studentInformation[1];
                float grade = float.Parse(studentInformation[2]);

                Student stundent = new Student(firstName, lastName, grade);
                students.Add(stundent);
            }

            List<Student> filter = students.OrderByDescending(number => number.Grade).ToList();

            foreach (Student student in filter)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:f2}");
            }
 


        }

        class Student
        {
            public Student(string firstName, string lastName, float grade)
            {
                this.FirstName = firstName;
                this.LastName = lastName;
                this.Grade = grade;
            }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public float Grade { get; set; }
        }

        //public override string ToString() => $"{FirstName} {LastName}: {Grade}";
    }
}
