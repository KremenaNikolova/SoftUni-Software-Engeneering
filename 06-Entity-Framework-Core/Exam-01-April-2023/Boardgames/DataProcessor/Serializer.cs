namespace Boardgames.DataProcessor
{
    using Boardgames.Data;
    using Boardgames.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using System.Text;
    using System.Xml.Linq;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Creators");
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            XmlSerializer serializer = new XmlSerializer(typeof(ExportCreatorDto[]), xmlRoot);

            var creators = context.Creators
                .Where(c=>c.Boardgames.Any())
                .ToArray()
                .Select(c=> new ExportCreatorDto()
                {
                    BoardgamesCount = c.Boardgames.Count,
                    CreatorName = $"{c.FirstName} {c.LastName}",
                    Boardgames = c.Boardgames.Select(b=> new ExportBoardgameDto()
                    {
                        BoardgameName= b.Name,
                        BoardgameYearPublished= b.YearPublished
                    })
                    .OrderBy(b=>b.BoardgameName)
                    .ToArray()
                })
                .OrderByDescending(c=>c.BoardgamesCount)
                .ThenBy(c=>c.CreatorName)
                .ToArray();

            using StringWriter writer = new StringWriter(sb);
            serializer.Serialize(writer, creators, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {
            var sellers = context.Sellers
                .Where(s => s.BoardgamesSellers
                    .Any(bs => bs.Boardgame.YearPublished >= year && bs.Boardgame.Rating<=rating))
                .Select(s=> new
                {
                    Name = s.Name,
                    Website= s.Website,
                    Boardgames = s.BoardgamesSellers
                    .Where(bs=>bs.Boardgame.Rating<=rating && bs.Boardgame.YearPublished>=year)
                    .Select(bs=> new
                    {
                        Name = bs.Boardgame.Name,
                        Rating = bs.Boardgame.Rating,
                        Mechanics = bs.Boardgame.Mechanics,
                        Category = bs.Boardgame.CategoryType.ToString()
                    })
                    .OrderByDescending(bs => bs.Rating)
                    .ThenBy(bs => bs.Name)
                    .ToArray()
                })
                .OrderByDescending(s=>s.Boardgames.Length)
                .ThenBy(s=>s.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(sellers, Formatting.Indented);
        }
    }
}