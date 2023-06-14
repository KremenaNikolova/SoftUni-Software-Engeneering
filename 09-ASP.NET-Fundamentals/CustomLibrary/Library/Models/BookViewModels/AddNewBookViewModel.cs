using System.ComponentModel.DataAnnotations;

using Library.Models.CategoryViewModels;

using static Library.Commons.Valdiations.BookValidations;
using static Library.Commons.ErrorMessages.BookErrorMessages;

namespace Library.Models.BookViewModels
{
    public class AddNewBookViewModel
    {
        public AddNewBookViewModel()
        {
            Categories = new HashSet<CategoryViewModel>();
        }

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = IncorectTitleInput)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(AuthorMaxLength, MinimumLength = AuthorMinLength, ErrorMessage = IncorectAuthorInput)]
        public string Author { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = IncorectDescriptionInput)]
        public string Description { get; set; } = null!;

        [Required]
        public string Url { get; set; } = null!;

        [Range(RatingMinValue, RatingMaxValue, ErrorMessage = IncorectRating)]
        public decimal Rating { get; set; }

        public int CategoryId { get; set; }
        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
