using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            List<Employee> people = new List<Employee>();

            Employee employee = new Employee("gosho");
            people.Add(employee);

            Manager manager = new Manager("gosho", new List<string>());
            List<string> documents = new List<string>() { "doc 1", "doc 2", "doc 3"};
            manager.Documents = documents;
            people.Add(manager);
            
            DetailsPrinter employees = new DetailsPrinter(people);
            employees.PrintDetails();
        }
    }
}
