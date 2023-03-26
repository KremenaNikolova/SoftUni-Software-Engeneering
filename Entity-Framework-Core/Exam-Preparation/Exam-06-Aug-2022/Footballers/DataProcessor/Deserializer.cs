namespace Footballers.DataProcessor
{
    using Footballers.Data;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Reflection.Metadata.Ecma335;
    using System.Security.AccessControl;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Coaches");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCoachDto[]), xmlRoot);

            using StringReader reader = new StringReader(xmlString);
            ImportCoachDto[] coachDtos = (ImportCoachDto[])serializer.Deserialize(reader)!;

            ICollection<Coach> coaches = new List<Coach>();

            foreach (var coachDto in coachDtos)
            {
                if (!IsValid(coachDto) || string.IsNullOrEmpty(coachDto.Nationality))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Coach coach = new Coach()
                {
                    Name= coachDto.Name,
                    Nationality = coachDto.Nationality
                };

                List<Footballer> footballers= new List<Footballer>();
                foreach (var footballerDto in coachDto.Footballers)
                {
                    DateTime StartDate;
                    bool isValidStartDate = DateTime.TryParseExact(footballerDto.ContractStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out StartDate);

                    DateTime EndDate;
                    bool isValidEndDate = DateTime.TryParseExact(footballerDto.ContractEndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out EndDate);

                    if (!IsValid(footballerDto) || string.IsNullOrEmpty(footballerDto.ContractStartDate) || string.IsNullOrEmpty(footballerDto.ContractEndDate) || StartDate>EndDate || !isValidStartDate || !isValidEndDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Footballer footballer = new Footballer()
                    {
                        Name = footballerDto.Name,
                        ContractStartDate = StartDate,
                        ContractEndDate = EndDate,
                        BestSkillType = (BestSkillType)Enum.ToObject(typeof(BestSkillType), footballerDto.BestSkillType),
                        PositionType = (PositionType)Enum.ToObject(typeof(PositionType), footballerDto.PositionType),
                        Coach = coach
                    };
                    footballers.Add(footballer);
                }
                coach.Footballers= footballers;

                coaches.Add(coach);
                sb.AppendLine(string.Format(SuccessfullyImportedCoach, coach.Name, coach.Footballers.Count));
            }

            context.Coaches.AddRange(coaches);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            List<ImportTeamDto> teamDtos = JsonConvert.DeserializeObject<List<ImportTeamDto>>(jsonString)!;

            List<Team> teams = new List<Team>();
            foreach (var teamDto in teamDtos)
            {
                if (!IsValid(teamDto) || string.IsNullOrEmpty(teamDto.Nationality) || teamDto.Trophies==0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                
                Team team = new Team()
                {
                    Name = teamDto.Name,
                    Nationality = teamDto.Nationality,
                    Trophies= teamDto.Trophies
                };

                foreach (var footballerDto in teamDto.Footballers!.Distinct())
                {
                    Footballer footballer = context.Footballers.Find(footballerDto);

                    if (footballer==null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    team.TeamsFootballers.Add(new TeamFootballer()
                    {
                        Team = team,
                        Footballer = footballer
                    });

                }

                teams.Add(team);
                sb.AppendLine(string.Format(SuccessfullyImportedTeam, team.Name.Trim(), team.TeamsFootballers.Count));
            }

            context.Teams.AddRange(teams);
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
