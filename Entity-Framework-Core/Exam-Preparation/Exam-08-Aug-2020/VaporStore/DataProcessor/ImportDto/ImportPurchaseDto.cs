using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.ImportDto
{
    [XmlType("Purchase")]
    public class ImportPurchaseDto
    {
        [Required]
        [XmlAttribute("title")]
        public string Title { get; set; } = null!;

        [Required]
        [XmlElement("Type")]
        public string Type { get; set; } = null!;

        [Required]
        [XmlElement("Key")]
        [RegularExpression(@"^([A-Z\d]{4}-){2}[A-Z\d]{4}$")]
        public string Key { get; set; } = null!;

        [Required]
        [XmlElement("Card")]
        [RegularExpression(@"^\d{4} \d{4} \d{4} \d{4}$")]
        public string Card { get; set; } = null!;

        [Required]
        [XmlElement("Date")]
        public string Date { get; set; } = null!;
    }
}
