using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trucks.Data.Models.Enums;
using Trucks.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType("Despatcher")]
    public class ImportDespatcherDto
    {
        [XmlElement("Name")]
        [Required]
        [MaxLength(40)]
        [MinLength(2)]
        public string Name { get; set; } = null!;

        [XmlElement("Position")]
        public string? Position { get; set; }

        [XmlArray("Trucks")]
        public ImportDespatcherTruckDto[] Trucks { get; set; } = null!;
    }

    [XmlType("Truck")]
    public class ImportDespatcherTruckDto
    {
        [XmlElement("RegistrationNumber")]
        [Required]
        [RegularExpression(@"[A-Z]{2}[0-9]{4}[A-Z]{2}$")]
        public string RegistrationNumber { get; set; } = null!;

        [XmlElement("VinNumber")]
        [StringLength(17)]
        public string VinNumber { get; set; } = null!;

        [XmlElement("TankCapacity")]
        [Range(950, 1420)]
        public int TankCapacity { get; set; }

        [XmlElement("CargoCapacity")]
        [Range(5000, 29000)]
        public int CargoCapacity { get; set; }

        [XmlElement("CategoryType")]
        [Required]
        public int CategoryType { get; set; }

        [XmlElement("MakeType")]
        [Required]
        public int MakeType { get; set; }
    }
}

