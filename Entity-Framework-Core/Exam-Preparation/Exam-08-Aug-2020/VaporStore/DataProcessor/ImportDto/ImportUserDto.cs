using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace VaporStore.DataProcessor.ImportDto
{
    public class ImportUserDto
    {
        [Required]
        [RegularExpression(@"^[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+$")]
        [Unicode(false)]
        public string Fullname { get; set; } = null!;

        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        public string Username { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Range(3, 103)]
        public int Age { get; set; }

        public ImportCardDto[] Cards { get; set; }
    }
}
