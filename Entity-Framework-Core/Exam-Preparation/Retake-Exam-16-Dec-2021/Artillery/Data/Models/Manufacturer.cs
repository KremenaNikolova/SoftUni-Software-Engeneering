using System.ComponentModel.DataAnnotations;

namespace Artillery.Data.Models
{
    public class Manufacturer
    {
        public Manufacturer()
        {
            Guns = new HashSet<Gun>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        [MinLength(4)]
        public string ManufacturerName { get; set; } = null!; 

        [Required]
        [MaxLength(100)]
        [MinLength(10)]
        public string Founded { get; set; } = null!;

        public virtual ICollection<Gun> Guns { get; set; } = null!;
    }
}
