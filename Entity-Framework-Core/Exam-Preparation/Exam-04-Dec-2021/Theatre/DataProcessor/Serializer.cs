namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Text;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatres = context.Theatres
                .Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count >= 20)
                .Select(t => new
                {
                    Name = t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome = t.Tickets
                    .Where(t => t.RowNumber >= 1 && t.RowNumber <= 5)
                    .Sum(t => t.Price),
                    Tickets = t.Tickets
                    .Where(t => t.RowNumber >= 1 && t.RowNumber <= 5)
                    .Select(t => new
                    {
                        Price = t.Price,
                        RowNumber = t.RowNumber
                    })
                    .OrderByDescending(t => t.Price)
                    .ToArray()
                })
                .OrderByDescending(t => t.Halls)
                .ThenBy(t => t.Name)
                .ToArray();

            return JsonConvert.SerializeObject(theatres, Formatting.Indented);
        }

        public static string ExportPlays(TheatreContext context, double raiting)
        {
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Plays");
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            XmlSerializer serializer = new XmlSerializer(typeof(ExportPlayDto[]), xmlRoot);

            ExportPlayDto[] plays = context.Plays
                .Where(p => p.Rating <= raiting)
                .ToArray()
                .Select(p => new ExportPlayDto()
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString("c"),
                    Rating = p.Rating == 0 ? "Premier" : p.Rating.ToString(),
                    Genre = p.Genre.ToString(),
                    Actors = p.Casts
                    .Where(c=>c.IsMainCharacter)
                    .Select(c => new ExportActorDto()
                    {
                        FullName = c.FullName,
                        PlayTitle = $"Plays main character in '{p.Title}'."
                    })
                    .OrderByDescending(c => c.FullName)
                    .ToArray()
                })
                .OrderBy(p => p.Title)
                .ThenByDescending(p => p.Genre)
                .ToArray();

            using StringWriter writer = new StringWriter(sb);
            serializer.Serialize(writer, plays, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
