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
public class Test_011_001_003
{
    [Test]
    public void ValidateOutput()
    {
        var services = new ServiceCollection()
            .AddDbContext<SoftUniContext>(b => b.UseInMemoryDatabase("SoftUni"));

        var serviceProvider = services.BuildServiceProvider();

        var context = serviceProvider.GetService<SoftUniContext>();

        this.Seed(context);

        string result = StartUp.GetLatestProjects(context).Trim();

        string expected = AssertMethod(context).Trim();

        Assert.AreEqual(expected, result, "Returned value is incorrect!");
    }

    private void Seed(SoftUniContext context)
    {
        var projects = new List<Project>();

        var projectNames = new[]
        {
            "Nez", "Modecom", "Asus", "Nasko", "Razor", "RepublicOfGamers",
            "Kitchen", "Mariela", "Coffee", "Pattern", "Venom", "Wow"
        };

        //M/d/yyyy h:mm:ss tt
        var projectStartDates = new[]
        {
            DateTime.ParseExact("1/2/2017 1:12:32", "M/d/yyyy h:mm:ss", null),
            DateTime.ParseExact("2/4/2017 11:12:32", "M/d/yyyy h:mm:ss", null),
            DateTime.ParseExact("3/6/2017 4:12:32", "M/d/yyyy h:mm:ss", null),
            DateTime.ParseExact("4/8/2017 8:12:32", "M/d/yyyy h:mm:ss", null),
            DateTime.ParseExact("5/10/2017 3:12:32", "M/d/yyyy h:mm:ss", null),
            DateTime.ParseExact("6/12/2017 7:12:32", "M/d/yyyy h:mm:ss", null),
        };

        var descriptions = new[]
        {
            "RandomText1", "RandomText1",
            "SuperText2", "SuperText2",
            "GodDamnText123", "GodDamnText3",
            "WowText123", "WowText33",
            "Description", "Description123",
            "Description123", "3123",
        };

        for (int i = 0; i < projectNames.Length; i++)
        {
            var project = new Project
            {
                Name = projectNames[i],
                StartDate = projectStartDates[i % projectStartDates.Length],
                Description = descriptions[i]
            };

            projects.Add(project);
        }

        context.Projects.AddRange(projects);
        context.SaveChanges();
    }

    public static string AssertMethod(SoftUniContext context)
    {
        var patternDate = "M/d/yyyy h:mm:ss tt";
        var content = new StringBuilder();

        var latestStartedProjects =
            context.Projects.OrderByDescending(project => project.StartDate)
                .Take(10)
                .OrderBy(project => project.Name)
                .ToList();

        foreach (var latestStartedProject in latestStartedProjects)
        {
            content.AppendLine($"{latestStartedProject.Name}");
            content.AppendLine($"{latestStartedProject.Description}");
            content.AppendLine($"{latestStartedProject.StartDate.ToString(patternDate, CultureInfo.InvariantCulture)}");
        }

        return content.ToString().TrimEnd();
    }
}