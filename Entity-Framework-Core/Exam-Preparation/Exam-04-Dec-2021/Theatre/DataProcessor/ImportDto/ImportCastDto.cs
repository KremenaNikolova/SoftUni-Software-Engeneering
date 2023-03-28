using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Theatre.Data.Models;
using System.Xml.Serialization;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Cast")]
    public class ImportCastDto
    {

        [Required]
        [MaxLength(30)]
        [MinLength(4)]
        [XmlElement("FullName")]
        public string FullName { get; set; } = null!;

        [XmlElement("IsMainCharacter")]
        public bool IsMainCharacter { get; set; }

        [Required]
        [RegularExpression(@"^(\+4{2})-(\d{2})-(\d{3})-(\d{4})$")]
        [XmlElement("PhoneNumber")]
        public string PhoneNumber { get; set; } = null!; //regex

        [XmlElement("PlayId")]
        public int PlayId { get; set; }
    }
}
