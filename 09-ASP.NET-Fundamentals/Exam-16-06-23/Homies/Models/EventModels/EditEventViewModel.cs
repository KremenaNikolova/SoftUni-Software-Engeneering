using Homies.Models.TypeModels;
using System.ComponentModel.DataAnnotations;

using static Homies.Commons.ValidationsConstant.EventValidations;
using static Homies.Commons.ErrorMessages.EventErrorMessages;

namespace Homies.Models.EventModels
{
    public class EditEventViewModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = IncorectNameInput)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = IncorectDescriptionInput)]
        public string Description { get; set; } = null!;

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public int TypeId { get; set; }

        public IEnumerable<TypeViewModel> Types { get; set; } = new HashSet<TypeViewModel>();
    }
}
