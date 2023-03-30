using System.ComponentModel.DataAnnotations;

namespace VaporStore.Data.Models
{
    public class User
    {
        public User()
        {
            Cards= new HashSet<Card>();
        }

        [Key]
        public int Id { get; set; } 

        [Required]
        [MaxLength(20)]
        public string Username { get; set; } = null!;

        [Required]
        public string FullName { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        public int Age { get; set; }

        public virtual ICollection<Card> Cards { get; set; }
    }
}
