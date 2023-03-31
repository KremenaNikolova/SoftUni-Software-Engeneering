using System.ComponentModel.DataAnnotations;

namespace Artillery.Data.Models
{
    public class Shell
    {
        public Shell()
        {
            Guns = new HashSet<Gun>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public double ShellWeight { get; set; }

        [Required]
        [MaxLength(30)]
        public string Caliber { get; set; } = null!;

        public virtual ICollection<Gun> Guns { get; set; } = null!;
    }
}
