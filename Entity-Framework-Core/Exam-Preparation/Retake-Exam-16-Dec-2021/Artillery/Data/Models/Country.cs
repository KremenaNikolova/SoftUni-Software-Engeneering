using System.ComponentModel.DataAnnotations;

namespace Artillery.Data.Models
{
    public class Country
    {
        public Country()
        {
            CountriesGuns = new HashSet<CountryGun>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        [MinLength(4)]
        public string CountryName { get; set; } = null!;

        [Required]
        [Range(50000, 10000000)]
        public int ArmySize { get; set; }

        public virtual ICollection<CountryGun> CountriesGuns { get; set; } = null!;
    }
}
