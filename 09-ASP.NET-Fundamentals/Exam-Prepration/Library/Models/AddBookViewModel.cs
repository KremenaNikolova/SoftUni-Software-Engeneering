using System.ComponentModel.DataAnnotations;

using static Library.Commons.Validations.BookValiadtions;
using static Library.Commons.ErrorMessages.BookErrorMessages;
using Library.Data.Models;

namespace Library.Models
{
    public class AddBookViewModel
    {
        public AddBookViewModel()
        {
            Categories = new HashSet<CategoryViewModel>();
        }

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = TitleErrorMessage)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(AuthorMaxLength, MinimumLength =AuthorMinLength, ErrorMessage = AuthorErrorMessage)]
        public string Author { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength =DescriptionMinLength, ErrorMessage = DescriptionErrorMessage)]
        public string Description { get; set; } = null!;

        [Required]
        public string Url { get; set; } = null!;

        [Range(0.00, 10.00, ErrorMessage = RatingErrorMessage)]
        public decimal Rating { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; } = null!;
    }
}
