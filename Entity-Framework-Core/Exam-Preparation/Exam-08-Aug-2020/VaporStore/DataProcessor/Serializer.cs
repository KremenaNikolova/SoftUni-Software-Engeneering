namespace VaporStore.DataProcessor
{ 
    using Data;
    using Newtonsoft.Json;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.ExportDto;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var games = context.Genres
                .Where(g => genreNames.Contains(g.Name))
                .ToArray()
                .Select(g => new
                {
                    Id = g.Id,
                    Genre = g.Name,
                    Games = g.Games
                    .Where(g => g.Purchases.Count > 0)
                    .Select(gm => new
                    {
                        Id = gm.Id,
                        Title = gm.Name,
                        Developer = gm.Developer.Name,
                        Tags = string.Join(", ", gm.GameTags.Select(gt => gt.Tag.Name)),
                        Players = gm.Purchases.Count
                    })
                    .OrderByDescending(gm => gm.Players)
                    .ThenBy(gm => gm.Id)
                    .ToArray(),
                    TotalPlayers = g.Games.Sum(gm => gm.Purchases.Count)
                })
                .OrderByDescending(g => g.TotalPlayers)
                .ThenBy(g => g.Id)
                .ToArray();

            return JsonConvert.SerializeObject(games, Formatting.Indented);
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string purchaseType)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Users");
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            XmlSerializer serializer = new XmlSerializer(typeof(ExportUserDto[]), xmlRoot);

            PurchaseType parsePurchaseType = (PurchaseType)Enum.Parse(typeof(PurchaseType), purchaseType);

            var users = context.Users
                .Where(u => u.Cards.Any(c => c.Purchases.Count>0))
                .ToArray()
                .Select(u => new ExportUserDto()
                {
                    Username = u.Username,
                    Purchases = context.Purchases
                    .Where(p=>p.Type == parsePurchaseType && p.Card.User.FullName==u.FullName)
                    .ToArray()
                    .OrderBy(p=>p.Date)
                    .Select(p => new ExportPurchaseDto()
                    {
                        Card = p.Card.Number,
                        Cvc = p.Card.Cvc,
                        Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                        Game = new ExportGameDto()
                        {
                            Title = p.Game.Name,
                            Genre = p.Game.Genre.Name,
                            Price = p.Game.Price,
                        }
                    })
                    .ToArray(),

                    TotalSpent = context.Purchases
                    .Where(p => p.Type == parsePurchaseType && p.Card.User.Username == u.Username)
                    .Sum(p=>p.Game.Price)
                })
                .Where(u=>u.Purchases.Length>0)
                .OrderByDescending(u=>u.TotalSpent)
                .ThenBy(u=>u.Username)
                .ToArray();


            //var users = context.Users
            //    .Where(u=>u.Cards.Any(c=>c.Purchases.Count>0))
            //    .ToArray()
            //    .Select(u=> new ExportUserDto()
            //    {
            //        Username= u.Username,
            //        Purchases = u.Cards
            //        .SelectMany(u=>u.Purchases
            //            .Where(p=>p.Type.ToString()== purchaseType)
            //            .OrderByDescending(p=>p.Date)
            //            .Select(p=> new ExportPurchaseDto()
            //        {
            //            Card = p.Card.Number,
            //            Cvc= p.Card.Cvc,
            //            Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
            //            Game = new ExportGameDto()
            //            {
            //                Title = p.Game.Name,
            //                Genre = p.Game.Genre.Name,
            //                Price= p.Game.Price,
            //            }
            //        }))
            //        .ToArray(),
            //
            //        TotalSpent = u.Cards.Sum(c=>c.Purchases.Sum(p=>p.Game.Price))
            //    })
            //    .OrderByDescending(u=>u.TotalSpent)
            //    .ThenBy(u=>u.Username)
            //    .ToArray();

            using StringWriter writer = new StringWriter(sb);
            serializer.Serialize(writer, users, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}