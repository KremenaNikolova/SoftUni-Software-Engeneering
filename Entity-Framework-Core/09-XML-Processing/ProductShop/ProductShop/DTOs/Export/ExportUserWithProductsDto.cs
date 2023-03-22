using ProductShop.Models;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{
    public class UsersCountDto
    {
        [XmlElement("count")]
        public int UsersCount { get; set; }

        [XmlArray("users")]
        public ExportUserWithProductsDto[] Users { get; set; } = null!;
    }

    [XmlType("User")]
    public class ExportUserWithProductsDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; } = null!;

        [XmlElement("lastName")]
        public string LastName { get; set; } = null!;

        [XmlElement("age")]
        public int? Age { get; set; }

        public SoldProductsDto SoldProducts { get; set; } = null!;
    }

    [XmlType("SoldProducts")]
    public class SoldProductsDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("products")]
        public ProductInfoDto[] Product { get; set; } = null!;

    }

    [XmlType("Product")]
    public class ProductInfoDto
    {

        [XmlElement("name")]
        public string Name { get; set; } = null!;

        [XmlElement("price")]
        public decimal Price { get; set; }
    }
}
