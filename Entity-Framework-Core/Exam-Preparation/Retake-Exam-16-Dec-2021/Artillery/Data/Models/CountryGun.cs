using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artillery.Data.Models
{
    public class CountryGun
    {
        [Required]
        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Gun))]
        public int GunId { get; set; }

        public virtual Gun Gun { get; set; } = null!;
    }
}
