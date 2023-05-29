namespace Text_Splitter_App.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using Text_Splitter_App.Commons;

    public class TextViewModel
    {
        [Required]
        [StringLength(ConstansValidations.TextMaximumLength,
            MinimumLength = ConstansValidations.TextMinimumLength,
            ErrorMessage = ConstansValidations.InvalidInput)]
        public string Text { get; set; } = null!;

        public string? SplitText { get; set; }
    }
}
