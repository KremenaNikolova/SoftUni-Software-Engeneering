using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string Author { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;


        public decimal Rating { get; set; }

        public int CategoryId { get; set; }
    }
}
