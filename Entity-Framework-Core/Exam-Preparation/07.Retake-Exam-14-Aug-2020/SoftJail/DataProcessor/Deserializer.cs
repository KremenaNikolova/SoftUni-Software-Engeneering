namespace SoftJail.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";

        private const string SuccessfullyImportedDepartment = "Imported {0} with {1} cells";

        private const string SuccessfullyImportedPrisoner = "Imported {0} {1} years old";

        private const string SuccessfullyImportedOfficer = "Imported {0} ({1} prisoners)";

        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            ImportDepartmentDto[] deparmentDtos = JsonConvert.DeserializeObject<ImportDepartmentDto[]>(jsonString)!;

            ICollection<Department> departments = new HashSet<Department>();

            foreach (var departmentDto in deparmentDtos)
            {
                if (!IsValid(departmentDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Department department = new Department()
                {
                    Name = departmentDto.Name
                };

                foreach (var cellDto in departmentDto.Cells)
                {
                    if (!IsValid(cellDto) || cellDto.CellNumber < 1)
                    {
                        sb.AppendLine(ErrorMessage);
                        department.Cells.Clear();
                        break;
                    }

                    department.Cells.Add(new Cell()
                    {
                        CellNumber = cellDto.CellNumber,
                        HasWindow = cellDto.HasWindow
                    });
                }

                if (!department.Cells.Any())
                {
                    continue;
                }

                departments.Add(department);
                sb.AppendLine(string.Format(SuccessfullyImportedDepartment, department.Name, department.Cells.Count));
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            ImportPrisonerDto[] prisonerDtos = JsonConvert.DeserializeObject<ImportPrisonerDto[]>(jsonString)!;

            ICollection<Prisoner> prisoners = new HashSet<Prisoner>();

            foreach (var prisonerDto in prisonerDtos)
            {
                bool isValidIncarcerationDate = DateTime.TryParseExact(prisonerDto.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime validIncarcerationDate);

                bool isValidReleaseDate = DateTime.TryParseExact(prisonerDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime validReleaseDate);

                if (!IsValid(prisonerDto)
                    || !isValidIncarcerationDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Prisoner prisoner = new Prisoner()
                {
                    FullName = prisonerDto.FullName,
                    Nickname = prisonerDto.Nickname,
                    Age = prisonerDto.Age,
                    IncarcerationDate = validIncarcerationDate,
                    ReleaseDate = isValidReleaseDate
                    ? validReleaseDate
                    : null,
                    Bail = prisonerDto.Bail,
                    CellId = prisonerDto.CellId
                };

                foreach (var mailDto in prisonerDto.Mails)
                {
                    if (!IsValid(mailDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        prisoner.Mails.Clear();
                        continue;
                    }

                    prisoner.Mails.Add(new Mail()
                    {
                        Description = mailDto.Description,
                        Sender = mailDto.Sender,
                        Address = mailDto.Address
                    });
                }

                if (!prisoner.Mails.Any())
                {
                    continue;
                }

                prisoners.Add(prisoner);
                sb.AppendLine(string.Format(SuccessfullyImportedPrisoner, prisoner.FullName, prisoner.Age));
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Officers");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportOfficerDto[]), xmlRoot);

            using StringReader reader = new StringReader(xmlString);

            ImportOfficerDto[] officerDtos = (ImportOfficerDto[])serializer.Deserialize(reader)!;

            ICollection<Officer> officers = new HashSet<Officer>();

            foreach (var officerDto in officerDtos)
            {
                bool isValidPosition = Enum.TryParse<Position>(officerDto.Position, out Position position);
                bool isValidWeapon = Enum.TryParse<Weapon>(officerDto.Weapon, out Weapon weapon);

                if (!IsValid(officerDto)
                    || !isValidPosition
                    || !isValidWeapon)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Officer officer= new Officer()
                {
                    FullName= officerDto.FullName,
                    Salary = officerDto.Salary,
                    Position= position,
                    Weapon= weapon,
                    DepartmentId= officerDto.DepartmentId
                };

                foreach (var prisonerDto in officerDto.Prisoners.Distinct())
                {
                    officer.OfficerPrisoners.Add(new OfficerPrisoner()
                    {
                        Officer = officer,
                        PrisonerId = prisonerDto.Id
                    });
                }

                officers.Add(officer);
                sb.AppendLine(string.Format(SuccessfullyImportedOfficer, officer.FullName, officer.OfficerPrisoners.Count));
            }

            context.Officers.AddRange(officers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}