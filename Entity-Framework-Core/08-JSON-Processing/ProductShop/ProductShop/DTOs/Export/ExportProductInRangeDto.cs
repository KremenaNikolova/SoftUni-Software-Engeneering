using System.Text.Json.Serialization;

namespace ProductShop.DTOs.Export;

public class ExportProductInRangeDto
{
    [JsonPropertyName("name")]
    public string ProductName { get; set; } = null!;

    [JsonPropertyName("price")]
    public decimal ProductPrice { get; set; }

    [JsonPropertyName("seller")]
    public string SellerFullName { get; set; } = null!;
}
