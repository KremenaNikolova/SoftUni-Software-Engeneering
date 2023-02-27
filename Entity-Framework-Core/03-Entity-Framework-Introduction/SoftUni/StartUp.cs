using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System.Globalization;
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

        //Problem 06 string output = AddNewAddressToEmployee(dbContext);

        //Problem 07 string output = GetEmployeesInPeriod(dbContext);

        //Problem 08 string output = GetAddressesByTown(dbContext);

        //Problem 09 string output = GetEmployee147(dbContext);

        //Problem 10 string output = GetDepartmentsWithMoreThan5Employees(dbContext);

        //Problem 11 string output = GetLatestProjects(dbContext);

        //Problem 12 string output = IncreaseSalaries(dbContext);

        //Problem 13 string output = GetEmployeesByFirstNameStartingWithSa(dbContext);

        //Problem 14 string output = DeleteProjectById(dbContext);

        //Problem 15 string output = RemoveTown(dbContext);

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


    //07. Employees and Projects
    public static string GetEmployeesInPeriod(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        DateTime earlyStartDate = new DateTime(2001, 1, 1);
        DateTime lastStartDate = new DateTime(2003, 12, 31);

        var employees = context.Employees
            .Take(10)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                ManagerFirstName = e.Manager!.FirstName,
                ManagerLastName = e.Manager.LastName,
                Projects = e.EmployeesProjects
                .Where(ep => ep.Project.StartDate >= earlyStartDate && ep.Project.StartDate <= lastStartDate)
                .Select(ep => new
                {
                    ep.Project.Name,
                    StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                    EndDate = ep.Project.EndDate.HasValue
                    ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                    : "not finished"
                })
                .ToArray()
            })
            .ToArray();

        foreach (var employee in employees)
        {
            sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");

            foreach (var project in employee.Projects)
            {
                sb.AppendLine($"--{project.Name} - {project.StartDate} - {project.EndDate}");
            }
        }

        return sb.ToString().TrimEnd();


    }


    //08. Addresses by Town
    public static string GetAddressesByTown(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var addresses = context.Addresses
            .OrderByDescending(a => a.Employees.Count)
            .ThenBy(a => a.Town!.Name)
            .ThenBy(a => a.AddressText)
            .Take(10)
            .Select(a => new
            {
                a.AddressText,
                TownName = a.Town!.Name,
                EmployeesCount = a.Employees.Count
            })
            .ToArray();

        foreach (var address in addresses)
        {
            sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeesCount} employees");
        }

        return sb.ToString().TrimEnd();
    }


    //09. Employee 147
    public static string GetEmployee147(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employeeProjects = context.Employees
            .Where(e => e.EmployeeId == 147)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.JobTitle,
                Projects = e.EmployeesProjects
                .OrderBy(ep => ep.Project.Name)
                .Select(ep => new
                {
                    ep.Project.Name
                })
                .ToArray()

            })
            .FirstOrDefault();

        sb.AppendLine($"{employeeProjects!.FirstName} {employeeProjects!.LastName} - {employeeProjects.JobTitle}");
        sb.AppendLine(string.Join(Environment.NewLine, employeeProjects.Projects.Select(p => p.Name)));

        return sb.ToString().TrimEnd();
    }


    //10. Departments with More Than 5 Employees
    public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var departments = context.Departments
            .Where(d => d.Employees.Count > 5)
            .OrderBy(d => d.Employees.Count)
            .ThenBy(d => d.Name)
            .Select(d => new
            {
                d.Name,
                ManagerFirstName = d.Manager.FirstName,
                ManagerLastName = d.Manager.LastName,
                Employees = d.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToArray()
            })
            .ToArray();


        foreach (var d in departments)
        {
            sb.AppendLine($"{d.Name} - {d.ManagerFirstName}  {d.ManagerLastName}");

            foreach (var e in d.Employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
            }
        }

        return sb.ToString().TrimEnd();
    }


    //11. Find Latest 10 Projects
    public static string GetLatestProjects(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var projects = context.Projects
            .OrderByDescending(p => p.StartDate)
            .Take(10)
            .Select(p => new
            {
                p.Name,
                p.Description,
                StartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
            })
            .OrderBy(p => p.Name)
            .ToArray();

        foreach (var p in projects)
        {
            sb.AppendLine(p.Name);
            sb.AppendLine(p.Description);
            sb.AppendLine(p.StartDate);
        }

        return sb.ToString().TrimEnd();
    }


    //12. Increase Salaries
    public static string IncreaseSalaries(SoftUniContext context)
    {
        decimal salaryModifier = 0.12m;

        int[] deparments = context.Departments
            .Where(d => d.Name == "Engineering" || d.Name == "Tool Design" || d.Name == "Marketing" || d.Name == "Information Services")
            .Select(d => d.DepartmentId)
            .ToArray();


        foreach (var employee in context.Employees)
        {
            foreach (var department in deparments)
            {
                if (employee.DepartmentId == department)
                {
                    employee.Salary += employee.Salary * salaryModifier;
                }
            }
        }

        context.SaveChanges();

        var employees = context.Employees
            .Where(e => deparments.Contains(e.DepartmentId))
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.Salary
            })
            .OrderBy(e=>e.FirstName)
            .ThenBy(e=>e.LastName)
            .ToArray();

        StringBuilder sb = new StringBuilder();

        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
        }

        return sb.ToString().TrimEnd();
    }


    //13. Find Employees by First Name Starting With Sa
    public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
    {
        string nameStartWith = "sa";

        var employees = context.Employees
            .Where(e => e.FirstName.ToLower().StartsWith(nameStartWith))
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.JobTitle,
                e.Salary
            })
            .OrderBy(e => e.FirstName)
            .ThenBy(e => e.LastName)
            .ToList();

        StringBuilder sb = new StringBuilder();

        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
        }

        return sb.ToString().TrimEnd();
    }


    //14. Delete Project by Id
    public static string DeleteProjectById(SoftUniContext context)
    {
        int projectIdForDelete = 2;

        var employeeProjecxt = context.EmployeesProjects
            .Where(p => p.ProjectId == projectIdForDelete);

        Project? project = context.Projects
            .FirstOrDefault(p => p.ProjectId == projectIdForDelete);

        context.EmployeesProjects.RemoveRange(employeeProjecxt!);
        context.Projects.Remove(project!);

        context.SaveChanges();

        string[] projects = context.Projects
            .Take(10)
            .Select(p=>p.Name)
            .ToArray();

        return string.Join(Environment.NewLine, projects);
            
    }


    //15. Remove Town
    public static string RemoveTown(SoftUniContext context)
    {
        string townNameForDelete = "Seattle";
        int? townIdForDelete = context.Towns
            .FirstOrDefault(t => t.Name == townNameForDelete)?
            .TownId;

        Address[] addressesForDelete = context.Addresses
            .Where(a => a.TownId == townIdForDelete)
            .ToArray();

        Town? townForDelete = context.Towns
            .FirstOrDefault(t => t.TownId == townIdForDelete);

        Employee[] employeesWithThatAddress = context.Employees
            .Where(e => addressesForDelete.Contains(e.Address))
            .ToArray();


        foreach (var e in employeesWithThatAddress)
        {
            e.AddressId = null;
        }


        int countDeletedTowns = context.Addresses
            .Count(a => a.TownId == townIdForDelete);


        context.Addresses.RemoveRange(addressesForDelete);
        context.Towns.Remove(townForDelete!);
        context.SaveChanges();

        return $"{countDeletedTowns} addresses in Seattle were deleted";   
    }
}