using System.ComponentModel.DataAnnotations;

using static Homies.Commons.ValidationsConstant.TypeValidations;

namespace Homies.Data.Models
{
    public class Type
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public IEnumerable<Event> Events { get; set; } = new HashSet<Event>();
    }
}
