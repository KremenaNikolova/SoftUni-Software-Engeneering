using System.ComponentModel.DataAnnotations;
using static Library.Commons.Validations.CategoryValidations;

namespace Library.Data.Models
{
    public class Category
    {
        public Category()
        {
            Books = new HashSet<Book>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Book> Books { get; set; }
    }
}
