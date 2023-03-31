using System.Xml.Serialization;

namespace VaporStore.DataProcessor.ExportDto
{
    [XmlType("Purchase")]
    public class ExportPurchaseDto
    {
        [XmlElement("Card")]
        public string Card { get; set; } = null!;

        [XmlElement("Cvc")]
        public string Cvc { get; set; } = null!;

        [XmlElement("Date")]
        public string Date { get; set; } = null!;

        public ExportGameDto Game { get; set; }
    }
}
