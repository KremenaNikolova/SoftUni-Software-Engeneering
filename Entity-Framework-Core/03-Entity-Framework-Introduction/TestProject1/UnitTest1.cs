using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

using SoftUni;
using SoftUni.Data;
using SoftUni.Models;

// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace

[TestFixture]
public class Test_007_001_001
{
    [Test]
    public void ValidateOutput()
    {
        var services = new ServiceCollection()
            .AddDbContext<SoftUniContext>(b => b.UseInMemoryDatabase(Guid.NewGuid().ToString()));

        var serviceProvider = services.BuildServiceProvider();

        var context = serviceProvider.GetService<SoftUniContext>();

        this.Seed(context);

        var assertService = serviceProvider.GetService<SoftUniContext>();

        string result = StartUp.GetEmployeesInPeriod(assertService).Trim();

        string expected = AssertMethod(assertService).Trim();

        Assert.AreEqual(expected, result, "Returned value is incorrect!");
    }

    private void Seed(SoftUniContext context)
    {
        List<Employee> employees = new List<Employee>();
        List<Project> projects = new List<Project>();
        List<EmployeeProject> employeeProjects = new List<EmployeeProject>();

        var firstNames = new[]
        {
            "Svetlin", "Mariela", "Ani", "Slavi", "Pesho",
            "Kircata", "Gosheto", "OnziTam", "DamnGod", "Test123",
        };

        var lastNames = new[]
        {
            "Nakov", "Cureva", "Topova", "Ludakov", "Peshev",
            "Wakov", "Sliperov", "Topalov", "Hristov", "Petrov"
        };

        var middleNames = new[]
        {
            "Petrov", "Kirov", "Stoyanov", "Angelov", "Vladimirov",
            "Karlov", "Markov", "Kostov", "Pavlov", "Georgiev"
        };

        var jobTitles = new[]
        {
            "Bartender", "Waiter", "Artist", "Shefa", "Driver",
            "IT", "DevOps", "DataScientist", "BusDriver", "Trainer",
        };

        var salaries = new[]
        {
            642.12m, 5235, 4000.32m, 25432, 2535235.33m,
            52354.12m, 956, 658.32m, 95846, 75343215.33m,
        };


        for (int i = 0; i < 10; i++)
        {
            var employee = new Employee
            {
                FirstName = firstNames[i],
                LastName = lastNames[i],
                MiddleName = middleNames[i],
                JobTitle = jobTitles[i],
                Salary = salaries[i],
            };

            employees.Add(employee);
        }

        for (int i = 0; i < employees.Count - 1; i++)
        {
            employees[i].Manager = employees[i + 1];
        }

        employees[employees.Count - 1].Manager = employees[0];

        var projectNames = new[]
        {
            "Crazy", "Project", "NoName", "WalkLikeABadAss","EnoughCoding",
            "Beer", "Wine", "MySpecialProject", "Can'tStop", "RedHotChilliPeppers"
        };

        var startDates = new[]
        {
            DateTime.Parse("12/12/2000"),
            DateTime.Parse("06/05/2001"),
            DateTime.Parse("11/11/2002"),
            DateTime.Parse("01/01/2003"),
        };

        for (int i = 0; i < 10; i++)
        {
            var project = new Project
            {
                Name = projectNames[i],
                StartDate = startDates[i % startDates.Length],
                EndDate = i % 3 == 0 ? (DateTime?)null : DateTime.Parse("5/12/2003")
            };

            projects.Add(project);
        }

        for (int i = 0; i < 10; i++)
        {
            var employeeProject = new EmployeeProject
            {
                EmployeeId = i + 1,
                ProjectId = i + 1
            };

            employeeProjects.Add(employeeProject);
        }

        context.Employees.AddRange(employees);
        context.Projects.AddRange(projects);
        context.EmployeesProjects.AddRange(employeeProjects);
        context.SaveChanges();
    }

    public static string AssertMethod(SoftUniContext context)
    {
        /*var employees = context.Employees
            .Include(x => x.Manager)
            .Include(x => x.EmployeesProjects)
            .ThenInclude(x => x.Project)
            .Where(employee => employee.EmployeesProjects
                .Any(project => project.Project.StartDate.Year >= 2001
                                && project.Project.StartDate.Year <= 2003))
            .Take(10)
            .ToList();*/

        var employees = context
                .Employees
                .Include(e => e.EmployeesProjects)
                .ThenInclude(ep => ep.Project)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    Projects = e.EmployeesProjects
                        .Select(ep => new
                        {
                            Name = ep.Project.Name,
                            StartDate = ep.Project.StartDate,
                            EndDate = ep.Project.EndDate,
                        })
                        .Where(ep => ep.StartDate.Year >= 2001 && ep.StartDate.Year <= 2003)
                        .ToList()
                })
                .ToList();

        var sb = new StringBuilder();
        string patternDateTime = "M/d/yyyy h:mm:ss tt";
        foreach (var employee in employees)
        {
            sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");

            foreach (var project in employee.Projects)
            {
                object projectEndDate = project.EndDate == null
                    ? "not finished"
                    : $"{((DateTime)project.EndDate).ToString(patternDateTime, CultureInfo.InvariantCulture)}";
                sb.AppendLine($"--{project.Name} - {project.StartDate.ToString(patternDateTime, CultureInfo.InvariantCulture)} - {projectEndDate}");
            }
        }

        return sb.ToString().TrimEnd();
    }
}