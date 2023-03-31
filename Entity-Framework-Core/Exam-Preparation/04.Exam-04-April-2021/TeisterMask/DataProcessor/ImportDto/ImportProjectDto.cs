using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Project")]
    public class ImportProjectDto
    {
        [Required]
        [MaxLength(40)]
        [MinLength(2)]
        [XmlElement("Name")]
        public string Name { get; set; } = null!;

        [Required]
        [XmlElement("OpenDate")]
        public string OpenDate { get; set; } = null!;

        [AllowNull]
        [XmlElement("DueDate")]
        public string? DueDate { get; set; } = null;

        [XmlArray("Tasks")]
        public ImportTaskDto[] Tasks { get; set; } = null!;
    }
}
