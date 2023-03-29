using System.Xml.Serialization;

namespace Theatre.DataProcessor.ExportDto
{
    [XmlType("Play")]
    public class ExportPlayDto
    {
        [XmlAttribute("Title")]
        public string Title { get; set; } = null!;

        [XmlAttribute("Duration")]
        public string Duration { get; set; } = null!;

        [XmlAttribute("Rating")]
        public string Rating { get; set; }

        [XmlAttribute("Genre")]
        public string Genre { get; set; } = null!;

        [XmlArray("Actors")]
        public ExportActorDto[] Actors { get; set; } = null!;
    }
}
