using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Theatre.DataProcessor.ImportDto
{
    public class ImportTheatreProjectionDto
    {
        [Required]
        [MaxLength(30)]
        [MinLength(4)]
        [JsonProperty("Name")]
        public string Name { get; set; } = null!;

        [Range(1, 10)]
        [JsonProperty("NumberOfHalls")]
        public sbyte NumberOfHalls { get; set; }

        [Required]
        [MaxLength(30)]
        [MinLength(4)]
        [JsonProperty("Director")]
        public string Director { get; set; } = null!;

        [JsonProperty("Tickets")]
        public ImportTicketDto[] Tickets { get; set; } = null!;
    }
}
