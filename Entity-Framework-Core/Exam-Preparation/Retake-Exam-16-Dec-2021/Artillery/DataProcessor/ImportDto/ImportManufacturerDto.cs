using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Manufacturer")]
    public class ImportManufacturerDto
    {
        [Required]
        [MaxLength(40)]
        [MinLength(4)]
        [XmlElement("ManufacturerName")]
        public string ManufacturerName { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        [MinLength(10)]
        [XmlElement("Founded")]
        public string Founded { get; set; } = null!;
    }
}
