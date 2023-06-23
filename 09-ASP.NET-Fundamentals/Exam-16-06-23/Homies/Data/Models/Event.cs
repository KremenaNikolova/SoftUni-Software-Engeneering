using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Homies.Commons.ValidationsConstant.EventValidations;

namespace Homies.Data.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string OrganiserId { get; set; } = null!;

        [Required]
        public IdentityUser Organiser { get; set; } = null!;

        public DateTime CreateOn { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        [ForeignKey(nameof(Type))]
        public int TypeId { get; set; }

        [Required]
        public Type Type { get; set; } = null!;

        public IEnumerable<EventParticipant> EventsParticipants { get; set; } = new HashSet<EventParticipant>();
    }
}
