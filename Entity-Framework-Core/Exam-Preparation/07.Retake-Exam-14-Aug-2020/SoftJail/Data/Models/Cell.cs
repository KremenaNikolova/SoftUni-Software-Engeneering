using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftJail.Data.Models
{
    public class Cell
    {
        public Cell()
        {
            Prisoners = new HashSet<Prisoner>();
        }

        [Key]
        public int Id { get; set; }

        public int CellNumber { get; set; }

        public bool HasWindow { get; set; }

        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }

        [Required]
        public virtual Department Department { get; set; } = null!;

        public virtual ICollection<Prisoner> Prisoners { get; set; }
    }
}
