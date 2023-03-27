namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ImportDto;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Countries");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCountryDto[]), xmlRoot);

            using StringReader reader = new StringReader(xmlString);
            ImportCountryDto[] countryDtos = (ImportCountryDto[])serializer.Deserialize(reader)!;

            ICollection<Country> countries = new List<Country>();
            foreach (var countryDto in countryDtos)
            {
                if (!IsValid(countryDto) || string.IsNullOrEmpty(countryDto.CountryName))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Country country = new Country()
                {
                    CountryName= countryDto.CountryName,
                    ArmySize = countryDto.ArmySize
                };

                countries.Add(country);
                sb.AppendLine(string.Format(SuccessfulImportCountry, countryDto.CountryName, countryDto.ArmySize));
            }

            context.Countries.AddRange(countries);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Manufacturers");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportManufacturerDto[]), xmlRoot);

            using StringReader reader = new StringReader(xmlString);
            ImportManufacturerDto[] manufacturerDtos = (ImportManufacturerDto[])serializer.Deserialize(reader)!;

            ICollection<Manufacturer> manufacturers = new List<Manufacturer>();
            foreach (var manufacturerDto in manufacturerDtos)
            {
                if (!IsValid(manufacturerDto) || manufacturers.Any(m=>m.ManufacturerName==manufacturerDto.ManufacturerName))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Manufacturer manufacturer = new Manufacturer()
                {
                    ManufacturerName = manufacturerDto.ManufacturerName,
                    Founded = manufacturerDto.Founded
                };

                var foundedLocation = manufacturer.Founded
                    .Split(", ")
                    .TakeLast(2)
                    .ToArray();

                manufacturers.Add(manufacturer);

                sb.AppendLine(string.Format(SuccessfulImportManufacturer, manufacturer.ManufacturerName, string.Join(", ", foundedLocation)));
            }
            context.Manufacturers.AddRange(manufacturers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Shells");
            XmlSerializer serialize = new XmlSerializer(typeof(ImportShellDto[]), xmlRoot);

            using StringReader reader = new StringReader(xmlString);
            ImportShellDto[] shellDtos = (ImportShellDto[])serialize.Deserialize(reader)!;

            ICollection<Shell> shells = new List<Shell>();
            foreach (var shellDto in shellDtos)
            {
                if (!IsValid(shellDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Shell shell = new Shell()
                {
                    ShellWeight= shellDto.ShellWeight,
                    Caliber = shellDto.Caliber
                };
                shells.Add(shell);

                sb.AppendLine(string.Format(SuccessfulImportShell, shell.Caliber, shell.ShellWeight));
            }

            context.Shells.AddRange(shells);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            ImportGunDto[] gunDtos = JsonConvert.DeserializeObject<ImportGunDto[]>(jsonString)!;

            List<Gun> guns = new List<Gun>();
            foreach (var gunDto in gunDtos)
            {
                GunType validGunType;
                bool isValidType = Enum.TryParse<GunType>(gunDto.GunType, out validGunType);
                if (!IsValid(gunDto) || !isValidType)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Gun gun = new Gun()
                {
                    ManufacturerId = gunDto.ManufacturerId,
                    GunWeight = gunDto.GunWeight,
                    BarrelLength = gunDto.BarrelLength,
                    NumberBuild = gunDto.NumberBuild,
                    Range = gunDto.Range,
                    GunType = validGunType,
                    ShellId = gunDto.ShellId
                };

                foreach (var countryId in gunDto.Countries)
                {
                    if (!context.Countries.Any(c => c.Id == countryId.Id))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    CountryGun countryGun = new CountryGun()
                    {
                        CountryId = countryId.Id,
                        Gun = gun
                    };
                    gun.CountriesGuns.Add(countryGun);
                }
                guns.Add(gun);

                sb.AppendLine(string.Format(SuccessfulImportGun, gun.GunType, gun.GunWeight, gun.BarrelLength));
                
            }

            context.Guns.AddRange(guns);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}