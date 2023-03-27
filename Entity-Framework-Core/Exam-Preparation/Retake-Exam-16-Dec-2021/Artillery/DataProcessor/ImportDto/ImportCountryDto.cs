using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Country")]
    public class ImportCountryDto
    {
        [Required]
        [MaxLength(60)]
        [MinLength(4)]
        [XmlElement("CountryName")]
        public string CountryName { get; set; } = null!;

        [Required]
        [Range(50000, 10000000)]
        [XmlElement("ArmySize")]
        public int ArmySize { get; set; }
    }
}
