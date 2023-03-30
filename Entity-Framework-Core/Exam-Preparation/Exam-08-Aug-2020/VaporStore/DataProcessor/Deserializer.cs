namespace VaporStore.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.ImportDto;

    public static class Deserializer
    {
        public const string ErrorMessage = "Invalid Data";

        public const string SuccessfullyImportedGame = "Added {0} ({1}) with {2} tags";

        public const string SuccessfullyImportedUser = "Imported {0} with {1} cards";

        public const string SuccessfullyImportedPurchase = "Imported {0} for {1}";

        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            ImportGameInfoDto[] gameDtos = JsonConvert.DeserializeObject<ImportGameInfoDto[]>(jsonString)!;

            ICollection<Game> games = new List<Game>();
            ICollection<Tag> tags = new List<Tag>();

            foreach (var gameDto in gameDtos)
            {
                bool isValidDate = DateTime.TryParseExact(gameDto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime validDate);

                if (!IsValid(gameDto)
                    || !isValidDate
                    || gameDto.Tags.Length<=0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Game game = new Game()
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = validDate,
                    Developer = games.Any(g=>g.Developer.Name==gameDto.Developer) 
                    ? games.First(g=>g.Developer.Name==gameDto.Developer).Developer
                    : new Developer() { Name = gameDto.Developer },
                    Genre = games.Any(g=>g.Genre.Name==gameDto.Genre)
                    ? games.First(g=>g.Genre.Name==gameDto.Genre).Genre
                    : new Genre() { Name= gameDto.Genre },
                };

                foreach (var tagName in gameDto.Tags.Distinct())
                {
                    Tag tag;
                    if (tags.Any(t => t.Name == tagName))
                    {
                        tag = tags.First(t => t.Name == tagName);
                    }
                    else
                    {
                        tag = new Tag() { Name = tagName };
                        tags.Add(tag);
                    }

                    game.GameTags.Add( new GameTag()
                    {
                        Tag = tag,
                        Game = game
                    });
                }

                games.Add(game);

                sb.AppendLine(string.Format(SuccessfullyImportedGame, game.Name, game.Genre.Name, game.GameTags.Count));
            }

            context.Games.AddRange(games);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            ImportUserDto[] userDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString)!;

            ICollection<User> users = new List<User>();

            foreach (var userDto in userDtos)
            {
                if (!IsValid(userDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                User user = new User()
                {
                    FullName = userDto.Fullname,
                    Username= userDto.Username,
                    Email = userDto.Email,
                    Age= userDto.Age
                };

                foreach (var cardDto in userDto.Cards)
                {
                    bool isValidType = Enum.TryParse(cardDto.Type, out CardType validType);

                    if (!IsValid(cardDto)
                        || !isValidType)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    user.Cards.Add(new Card()
                    {
                        Number = cardDto.Number,
                        Cvc = cardDto.Cvc,
                        Type = validType
                    });
                }

                users.Add(user);
                sb.AppendLine(string.Format(SuccessfullyImportedUser, user.Username, user.Cards.Count));
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Purchases");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportPurchaseDto[]), xmlRoot);

            using StringReader reader = new StringReader(xmlString);
            ImportPurchaseDto[] purchaseDtos = (ImportPurchaseDto[])serializer.Deserialize(reader)!;

            ICollection<Purchase> purchases = new List<Purchase>();

            foreach (var purchaseDto in purchaseDtos)
            {
                bool isValidType = Enum.TryParse(purchaseDto.Type, out PurchaseType validType);

                bool isValidDate = DateTime.TryParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime validDate);

                if (!IsValid(purchaseDto)
                    || !isValidType
                    || !isValidDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Purchase purchase = new Purchase()
                {
                    Game = context.Games.First(g=>g.Name== purchaseDto.Title),
                    Type = validType,
                    ProductKey = purchaseDto.Key,
                    Card = context.Cards.First(g=>g.Number == purchaseDto.Card),
                    Date = validDate
                };

                purchases.Add(purchase);
                string userName = purchase.Card.User.Username;

                sb.AppendLine(string.Format(SuccessfullyImportedPurchase, purchaseDto.Title, userName));
            }

            context.Purchases.AddRange(purchases);
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