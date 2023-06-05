using System.ComponentModel.DataAnnotations;

using static Forum.Common.Validations.EntityValidations;

namespace Forum.ViewModels.Post
{
    public class PostFormModel
    {
        [Required]
        [StringLength(PostValidation.MaxTitleLength, MinimumLength = PostValidation.MinTitleLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(PostValidation.MaxContentLength, MinimumLength = PostValidation.MinContentLength)]
        public string Content { get; set; } = null!;
    }
}
