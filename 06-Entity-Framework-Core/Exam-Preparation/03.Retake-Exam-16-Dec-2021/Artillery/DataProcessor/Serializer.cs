﻿
namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportShells(ArtilleryContext context, double shellWeight)
        {
            var shells = context.Shells
                .Where(s => s.ShellWeight > shellWeight)
                .ToArray()
                .Select(s => new
                {
                    ShellWeight = s.ShellWeight,
                    Caliber = s.Caliber,
                    Guns = s.Guns
                    .Where(g => g.GunType.ToString() == "AntiAircraftGun")
                    .Select(g => new
                    {
                        GunType = g.GunType.ToString(),
                        GunWeight = g.GunWeight,
                        BarrelLength = g.BarrelLength,
                        Range = g.Range > 3000 ? "Long-range" : "Regular range",
                    })
                    .OrderByDescending(g=>g.GunWeight)
                    .ToArray()
                })
                .OrderBy(s=>s.ShellWeight)
                .ToArray();

            return JsonConvert.SerializeObject(shells, Formatting.Indented);
        }

        public static string ExportGuns(ArtilleryContext context, string manufacturer)
        {
            ExportGunDto[] guns = context.Guns
                .Where(g=>g.Manufacturer.ManufacturerName == manufacturer)
                .ToArray()
                .Select(g=> new ExportGunDto()
                {
                    Manufacturer = g.Manufacturer.ManufacturerName,
                    GunType = g.GunType.ToString(),
                    GunWeight= g.GunWeight,
                    BarrelLength = g.BarrelLength,
                    Range = g.Range,
                    Countries = g.CountriesGuns
                    .Where(cg=>cg.Country.ArmySize > 4500000)
                    .Select(cg=> new ExportCountryDto()
                    {
                        CountryName = cg.Country.CountryName,
                        ArmySize = cg.Country.ArmySize
                    })
                    .OrderBy(cg=>cg.ArmySize)
                    .ToArray()
                })
                .OrderBy(g=>g.BarrelLength)
                .ToArray();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Guns");
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(typeof(ExportGunDto[]), xmlRoot);

            using StringWriter writer= new StringWriter(sb);
            serializer.Serialize(writer, guns, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
