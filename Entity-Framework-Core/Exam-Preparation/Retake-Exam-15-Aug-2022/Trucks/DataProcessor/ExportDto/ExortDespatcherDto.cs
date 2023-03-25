using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Trucks.Data.Models.Enums;

namespace Trucks.DataProcessor.ExportDto
{
    [XmlType("Despatcher")]
    public class ExortDespatcherDto
    {
        [XmlAttribute("TrucksCount")]
        public int TruckCount { get; set; }

        [XmlElement("DespatcherName")]
        public string DespatcherName { get; set; } = null!;

        [XmlArray("Trucks")]
        public ExportDespatcherTrucksDto[] Trucks { get; set; } = null!;
    }

    [XmlType("Truck")]
    public class ExportDespatcherTrucksDto
    {
        [XmlElement("RegistrationNumber")]
        public string RegistrationNumber { get; set; } = null!;

        [XmlElement("Make")]
        public MakeType MakeType { get; set; }
    }
}
