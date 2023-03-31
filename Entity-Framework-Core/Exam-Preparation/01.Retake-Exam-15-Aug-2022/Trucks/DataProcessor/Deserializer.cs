namespace Trucks.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using AutoMapper;
    using Data;
    using Microsoft.Data.SqlClient;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using Trucks.Data.Models;
    using Trucks.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(mc => mc.AddProfile<TrucksProfile>()));
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Despatchers");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportDespatcherDto[]), xmlRoot);

            using StringReader reader = new StringReader(xmlString);
            ImportDespatcherDto[] despatcherDtos = (ImportDespatcherDto[])serializer.Deserialize(reader)!;

            ICollection<Despatcher> despatchers = new HashSet<Despatcher>();

            foreach (ImportDespatcherDto despatcherDto in despatcherDtos)
            {
                if (!IsValid(despatcherDto) || string.IsNullOrEmpty(despatcherDto.Position))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Despatcher despatcher = new Despatcher()
                {
                    Name = despatcherDto.Name,
                    Position = despatcherDto.Position,
                };

                foreach (ImportDespatcherTruckDto truckDto in despatcherDto.Trucks)
                {
                    if (!IsValid(truckDto) || string.IsNullOrEmpty(truckDto.VinNumber))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    Truck truck = mapper.Map<Truck>(truckDto);
                    despatcher.Trucks.Add(truck);
                }
                despatchers.Add(despatcher);
                sb.AppendLine(string.Format(SuccessfullyImportedDespatcher, despatcher.Name, despatcher.Trucks.Count));
            }

            context.Despatchers.AddRange(despatchers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();

        }
        public static string ImportClient(TrucksContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            List<ImportClientDto> clientDtos = JsonConvert.DeserializeObject<List<ImportClientDto>>(jsonString)!;

            List<Client> clients = new List<Client>();

            foreach (var clientDto in clientDtos)
            {
                if (!IsValid(clientDto) || string.IsNullOrEmpty(clientDto.Name) || string.IsNullOrEmpty(clientDto.Nationality) || clientDto.Type == "usual")
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Client client = new Client()
                {
                    Name = clientDto.Name,
                    Nationality = clientDto.Nationality,
                    Type = clientDto.Type
                };

                foreach (var truckId in clientDto.Trucks.Distinct())
                {
                    if (!context.Trucks.Any(t=>t.Id==truckId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    ClientTruck clientTruck = new ClientTruck()
                    {
                        Client = client,
                        TruckId = truckId
                    };

                    client.ClientsTrucks.Add(clientTruck);
                }

                clients.Add(client);
                sb.AppendLine(string.Format(SuccessfullyImportedClient, client.Name, client.ClientsTrucks.Count));
            }

            context.Clients.AddRange(clients); 
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