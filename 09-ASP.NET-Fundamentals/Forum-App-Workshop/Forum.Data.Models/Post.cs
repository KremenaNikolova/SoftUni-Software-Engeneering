using System.ComponentModel.DataAnnotations;

using static Forum.Common.Validations.EntityValidations;

namespace Forum.Data.Models
{
    public class Post
    {
        public Post()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(PostValidation.MaxTitleLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(PostValidation.MaxContentLength)]
        public string Content { get; set; } = null!;
    }
}
