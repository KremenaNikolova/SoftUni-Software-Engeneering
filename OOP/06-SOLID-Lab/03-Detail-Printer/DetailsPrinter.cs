using P03.DetailPrinter.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public class DetailsPrinter //този Detail Printer не трябва да пита какъв служител му е даден.
                                //Detail Printer needs to just print details for all kinds of employees. 
                                //When a new kind of employee is added, you will only need to add a new class and nothing more.
    {
        private IList<Employee> employees;

        public DetailsPrinter(IList<Employee> employees)
        {
            this.employees = employees;
        }

        public void PrintDetails()
        {
            foreach (var employee in employees)
            {
                Console.WriteLine(employee.Print());
            }
        }
    }
}
