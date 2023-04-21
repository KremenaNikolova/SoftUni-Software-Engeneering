using Newtonsoft.Json;

namespace ProductShop.DTOs.Export;

//we need from that class if we not work with anonymous object
public class ExportProductInRangeDto
{
    [JsonProperty("name")]
    public string ProductName { get; set; } = null!;

    [JsonProperty("price")]
    public decimal ProductPrice { get; set; }

    [JsonProperty("seller")]
    public string SellerFullName { get; set; } = null!;
}
