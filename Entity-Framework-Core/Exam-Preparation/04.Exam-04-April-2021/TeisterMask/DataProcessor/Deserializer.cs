// ReSharper disable InconsistentNaming

namespace TeisterMask.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using System.Text;
    using System.Xml.Serialization;
    using TeisterMask.DataProcessor.ImportDto;
    using TeisterMask.Data.Models;
    using Microsoft.Data.SqlClient.Server;
    using System.Globalization;
    using TeisterMask.Data.Models.Enums;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Projects");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportProjectDto[]), xmlRoot);

            using StringReader reader = new StringReader(xmlString);
            ImportProjectDto[] projectDtos = (ImportProjectDto[])serializer.Deserialize(reader)!;

            ICollection<Project> projects = new List<Project>();

            foreach (var projectDto in projectDtos)
            {
                bool isValidProjectOpenDate = DateTime.TryParseExact(projectDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime validProjectOpenDate);

                bool isEmtyProjectDueDate = DateTime.TryParseExact(projectDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime validProjectDueDate);

                if (!IsValid(projectDto)
                    || !isValidProjectOpenDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }


                Project project = new Project()
                {
                    Name = projectDto.Name,
                    OpenDate = validProjectOpenDate,
                    DueDate = isEmtyProjectDueDate
                        ? validProjectDueDate
                        : null
                };

                foreach (var taskDto in projectDto.Tasks)
                {
                    bool isValidTaskOpenDate = DateTime.TryParseExact(taskDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime taskOpenDate);

                    bool isValidTaskDueDate = DateTime.TryParseExact(taskDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime taskDueDate);


                    if (!IsValid(taskDto)
                        || taskOpenDate < validProjectOpenDate
                        || (isEmtyProjectDueDate && taskDueDate > validProjectDueDate)
                        || !isValidTaskDueDate
                        || !isValidTaskOpenDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    project.Tasks.Add(new Task()
                    {
                        Name = taskDto.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)taskDto.ExecutionType,
                        LabelType = (LabelType)taskDto.LabelType
                    });
                }

                projects.Add(project);

                sb.AppendLine(string.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count));
            }

            context.Projects.AddRange(projects);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            ImportEmployeeDto[] employeeDtos = JsonConvert.DeserializeObject<ImportEmployeeDto[]>(jsonString)!;

            ICollection<Employee> employees = new List<Employee>();

            foreach (var employeeDto in employeeDtos)
            {
                if (!IsValid(employeeDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Employee employee = new Employee()
                {
                    Username = employeeDto.Username,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone
                };

                foreach (var taskId in employeeDto.Tasks.Distinct())
                {
                    if (!context.Tasks.Any(t => t.Id == taskId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    employee.EmployeesTasks.Add(new EmployeeTask()
                    {
                        Employee = employee,
                        TaskId = taskId
                    });
                }

                employees.Add(employee);

                sb.AppendLine(string.Format(SuccessfullyImportedEmployee, employee.Username, employee.EmployeesTasks.Count));
            }

            context.Employees.AddRange(employees);
            context.SaveChanges();

            return sb.ToString().TrimEnd();

        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}