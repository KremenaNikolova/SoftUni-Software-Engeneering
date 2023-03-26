using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Footballers.Data.Models
{
    public class TeamFootballer
    {
        [Required]
        [ForeignKey(nameof(Team))]
        public int TeamId { get; set; }

        public virtual Team Team { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Footballer))]
        public int FootballerId  { get; set; }

        public virtual Footballer Footballer { get; set; } = null!;
    }
}
