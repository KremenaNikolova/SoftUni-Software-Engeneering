using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class ImportEmployeeDto
    {
        [Required]
        [MaxLength(40)]
        [MinLength(3)]
        [RegularExpression(@"^[a-zA-Z\d]+$")]
        [JsonProperty("Username")]
        public string Username { get; set; } = null!;

        [Required]
        [EmailAddress]
        [JsonProperty("Email")]
        public string Email { get; set; } = null!;

        [Required]
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$")]
        [JsonProperty("Phone")]
        public string Phone { get; set; } = null!;

        [JsonProperty("Tasks")]
        public int[] Tasks { get; set; }
    }
}
