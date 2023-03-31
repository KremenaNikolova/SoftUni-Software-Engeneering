
using System.ComponentModel.DataAnnotations;
using Theatre.Data.Models.Enums;

namespace Theatre.Data.Models
{
    public class Play
    {
        public Play()
        {
            Casts = new HashSet<Cast>();
            Tickets = new HashSet<Ticket>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; } = null!;

        public TimeSpan Duration { get; set; } //in format {hours:minutes:seconds}, 

        public float Rating { get; set; }

        public Genre Genre { get; set; }

        [Required]
        [MaxLength(700)]
        public string Description { get; set; } = null!;

        [Required]
        [MaxLength(30)]
        public string Screenwriter { get; set; } = null!;

        public virtual ICollection<Cast> Casts { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }

    }
}
