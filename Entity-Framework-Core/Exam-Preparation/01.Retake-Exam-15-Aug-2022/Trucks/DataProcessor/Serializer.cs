namespace Trucks.DataProcessor
{
    using AutoMapper;
    using Data;
    using Newtonsoft.Json;
    using System.Text;
    using System.Xml.Serialization;
    using Trucks.Data.Models.Enums;
    using Trucks.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
        {
            StringBuilder sb = new StringBuilder();

            ExortDespatcherDto[] despatchers = context.Despatchers
                .Where(d => d.Trucks.Any())
                .ToArray()
                .Select(d => new ExortDespatcherDto()
                {
                    TruckCount = d.Trucks.Count(),
                    DespatcherName = d.Name,
                    Trucks = d.Trucks.Select(t => new ExportDespatcherTrucksDto()
                    {
                        RegistrationNumber = t.RegistrationNumber,
                        MakeType = (MakeType)Enum.ToObject(typeof(MakeType), t.MakeType)
                    })
                    .OrderBy(t => t.RegistrationNumber)
                    .ToArray()

                })
                .OrderByDescending(d=>d.TruckCount)
                .ThenBy(d=>d.DespatcherName)
                .ToArray();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Despatchers");
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            XmlSerializer serializer = new XmlSerializer(typeof(ExortDespatcherDto[]), xmlRoot);

            using StringWriter writer = new StringWriter(sb);
            serializer.Serialize(writer, despatchers, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
        {
            var clients = context.Clients
                .Where(c => c.ClientsTrucks.Any(ct => ct.Truck.TankCapacity >= capacity))
                .ToArray()
                .Select(c => new
                {
                    c.Name,
                    Trucks = c.ClientsTrucks
                    .Where(cl => cl.Truck.TankCapacity >= capacity)
                    .Select(cl => new
                    {
                        TruckRegistrationNumber = cl.Truck.RegistrationNumber,
                        cl.Truck.VinNumber,
                        cl.Truck.TankCapacity,
                        cl.Truck.CargoCapacity,
                        CategoryType = cl.Truck.CategoryType.ToString(),
                        MakeType = cl.Truck.MakeType.ToString(),
                    })
                    
                    .OrderBy(cl => cl.MakeType)
                    .ThenByDescending(cl=>cl.CargoCapacity)
                    .ToArray()
                })
                .OrderByDescending(c=>c.Trucks.Count())
                .ThenBy(c=>c.Name)
                .Take(10)
                .ToArray();

            return JsonConvert.SerializeObject(clients, Formatting.Indented);
        }
    }
}
