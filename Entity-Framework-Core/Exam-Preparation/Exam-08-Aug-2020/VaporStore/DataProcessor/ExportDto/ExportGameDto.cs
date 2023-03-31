using System.Xml.Serialization;

namespace VaporStore.DataProcessor.ExportDto
{
    [XmlType("Game")]
    public class ExportGameDto
    {
        [XmlAttribute("title")]
        public string Title { get; set; } = null!;

        [XmlElement("Genre")]
        public string Genre { get; set; } = null!;

        [XmlElement("Price")]
        public decimal Price { get; set; }
    }
}
