using System.ComponentModel.DataAnnotations;

namespace VaporStore.Data.Models
{
    public class Developer
    {
        public Developer()
        {
            Games = new HashSet<Game>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public virtual ICollection<Game> Games { get; set; }
    }
}
