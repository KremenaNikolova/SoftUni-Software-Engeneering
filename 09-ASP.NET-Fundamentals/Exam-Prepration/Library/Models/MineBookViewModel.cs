using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class MineBookViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string Author { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public string Category { get; set; } = null!;
    }
}
