using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System.Text;

namespace SoftUni;

public class StartUp
{
    static void Main(string[] args)
    {
        SoftUniContext dbContext = new SoftUniContext();

        //Problem 03: string output = GetEmployeesFullInformation(dbContext); 

        //Problem 04: string output = GetEmployeesWithSalaryOver50000(dbContext);

        //Problem 05 string output = GetEmployeesFromResearchAndDevelopment(dbContext);

        string output = AddNewAddressToEmployee(dbContext);

        Console.WriteLine(output);
    }

    //03. Employees Full Information
    public static string GetEmployeesFullInformation(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employees = context.Employees
            .OrderBy(e => e.EmployeeId)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.MiddleName,
                e.JobTitle,
                e.Salary
            })
            .ToArray();

        foreach (var employee in employees)
        {
            sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
        }

        return sb.ToString().TrimEnd();
    }


    //04. Employees with Salary Over 50 000
    public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employees = context.Employees
            .Where(e => e.Salary > 50000)
            .OrderBy(e => e.FirstName)
            .Select(e => new
            {
                e.FirstName,
                e.Salary
            })
            .ToArray();

        foreach (var employee in employees)
        {
            sb.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
        }

        return sb.ToString().TrimEnd();
    }


    //05. Employees from Research and Development
    public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employees = context.Employees
            .Where(e => e.Department.Name == "Research and Development")
            .OrderBy(e => e.Salary)
            .ThenByDescending(e => e.FirstName)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                departmentName = e.Department.Name,
                e.Salary
            })
            .ToArray();

        foreach (var employee in employees)
        {
            sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.departmentName} - ${employee.Salary:f2}");
        }

        return sb.ToString().TrimEnd();
    }


    //06. Adding a New Address and Updating Employee
    public static string AddNewAddressToEmployee(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        Address newAddress = new Address()
        {
            AddressText = "Vitoshka 15",
            TownId = 4
        };

        context.Addresses.Add(newAddress);

        Employee? employee = context.Employees
            .FirstOrDefault(e => e.LastName == "Nakov");

        employee!.Address = newAddress;

        context.SaveChanges();

        string[] orderEmployees = context.Employees
            .OrderByDescending(e => e.AddressId)
            .Take(10)
            .Select(e => e.Address.AddressText)
            .ToArray();

        foreach (var orderEmployee in orderEmployees)
        {
            sb.AppendLine($"{orderEmployee}");
        }

        return sb.ToString().TrimEnd();
    }
}