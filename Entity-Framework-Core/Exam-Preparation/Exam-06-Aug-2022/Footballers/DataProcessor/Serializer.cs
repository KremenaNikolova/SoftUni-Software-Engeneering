namespace Footballers.DataProcessor
{
    using Data;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            StringBuilder sb = new StringBuilder();

            var coaches = context.Coaches
                .Where(c=>c.Footballers.Any())
                .ToArray()
                .Select(c=> new ExportCoachDto()
                {
                    FootballerCount = c.Footballers.Count(),
                    Name= c.Name,
                    Footballer = c.Footballers.Select(f=> new ExportFootballerDto()
                    {
                        Name = f.Name,
                        Position = (PositionType)Enum.ToObject(typeof(PositionType), f.PositionType)
                    })
                    .OrderBy(f => f.Name)
                    .ToArray()
                })
                .OrderByDescending(c=>c.FootballerCount)
                .ThenBy(c=>c.Name)
                .ToArray();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Coaches");
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            XmlSerializer serializer = new XmlSerializer(typeof(ExportCoachDto[]), xmlRoot);

            using StringWriter writer = new StringWriter(sb);
            serializer.Serialize(writer, coaches, namespaces);

            return sb.ToString().TrimEnd();

        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var teams = context.Teams
                .Where(t=> t.TeamsFootballers.Any(tf=>tf.Footballer.ContractStartDate>=date))
                .ToArray()
                .Select(t=> new
                {
                    Name = t.Name,
                    Footballers = t.TeamsFootballers
                    .Where(tf=>tf.Footballer.ContractStartDate>=date)
                    .OrderByDescending(tf => tf.Footballer.ContractEndDate)
                    .ThenBy(tf => tf.Footballer.Name)
                    .Select(tf => new
                    {
                        FootballerName = tf.Footballer.Name,
                        ContractStartDate = tf.Footballer.ContractStartDate.ToString("d", CultureInfo.InvariantCulture),
                        ContractEndDate = tf.Footballer.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
                        BestSkillType = tf.Footballer.BestSkillType.ToString(),
                        PositionType = tf.Footballer.PositionType.ToString()
                    })
                    .ToArray()
                })
                .OrderByDescending(t=>t.Footballers.Count())
                .ThenBy(t=>t.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(teams, Formatting.Indented) ;
        }
    }
}
