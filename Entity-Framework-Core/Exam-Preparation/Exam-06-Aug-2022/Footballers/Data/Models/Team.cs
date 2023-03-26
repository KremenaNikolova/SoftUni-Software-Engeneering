using System.ComponentModel.DataAnnotations;

namespace Footballers.Data.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        [MinLength(3)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(40)]
        [MinLength(2)]
        public string Nationality { get; set; } = null!;

        [Required]
        public int Trophies { get; set; }

        public virtual ICollection<TeamFootballer> TeamsFootballers { get; set; } = null!;
    }
}
