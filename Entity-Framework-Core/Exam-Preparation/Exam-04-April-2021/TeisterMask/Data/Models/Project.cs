using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace TeisterMask.Data.Models
{
    public class Project
    {
        public Project()
        {
            Tasks = new HashSet<Task>();    
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; } = null!;

        public DateTime OpenDate { get; set; }

        [MaybeNull]
        public DateTime? DueDate { get; set; } = null;

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
