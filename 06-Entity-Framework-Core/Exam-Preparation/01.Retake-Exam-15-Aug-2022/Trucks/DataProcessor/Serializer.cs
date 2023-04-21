namespace Trucks.DataProcessor
{
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

            var despatchers = context.Despatchers
                .Where(d=>d.Trucks.Any())
                .Select(d=> new ExportDespatcherDto()
                {
                    TrucksCount = d.Trucks.Count,
                    DespatcherName = d.Name,
                    Trucks = d.Trucks.Select(t=>new ExportTruckDto()
                    {
                        RegistrationNumber = t.RegistrationNumber!,
                        Make = t.MakeType.ToString()
                    })
                    .OrderBy(t => t.RegistrationNumber)
                    .ToArray()
                })
                .OrderByDescending(d=>d.TrucksCount)
                .ThenBy(d=>d.DespatcherName)
                .ToArray();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Despatchers");
            XmlSerializerNamespaces namespaces= new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            XmlSerializer serializer = new XmlSerializer(typeof(ExportDespatcherDto[]), xmlRoot);

            using StringWriter writer= new StringWriter(sb);
            serializer.Serialize(writer, despatchers, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
        {
            var trucks = context.Clients
                .Where(c=>c.ClientsTrucks.Any() 
                    && c.ClientsTrucks.Any(ct=>ct.Truck.TankCapacity>=capacity))
                .ToArray()
                .Select(c=> new
                {
                    Name = c.Name,
                    Trucks = c.ClientsTrucks
                    .Where(ct=>ct.Truck.TankCapacity>=capacity)
                    .Select(ct=> new
                    {
                        TruckRegistrationNumber = ct.Truck.RegistrationNumber,
                        VinNumber = ct.Truck.VinNumber,
                        TankCapacity = ct.Truck.TankCapacity,
                        CargoCapacity = ct.Truck.CargoCapacity,
                        CategoryType = ct.Truck.CategoryType.ToString(),
                        MakeType = ct.Truck.MakeType.ToString()
                    })
                    .OrderBy(ct=>ct.MakeType)
                    .ThenByDescending(ct=>ct.CargoCapacity)
                    .ToArray()
                })
                .OrderByDescending(c=>c.Trucks.Count())
                .ThenBy(c=>c.Name)
                .Take(10)
                .ToArray();

            return JsonConvert.SerializeObject(trucks, Formatting.Indented);
        }
    }
}
