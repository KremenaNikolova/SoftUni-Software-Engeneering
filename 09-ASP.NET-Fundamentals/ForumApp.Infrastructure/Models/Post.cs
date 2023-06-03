namespace ForumApp.Data.Models

{
    using ForumApp.Common.Validations;

    using System.ComponentModel.DataAnnotations;

    public class Post
    {
        public Post() 
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(PostValidation.TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(PostValidation.ContentMaxLength)]
        public string Content { get; set; } = null!;
    }
}
