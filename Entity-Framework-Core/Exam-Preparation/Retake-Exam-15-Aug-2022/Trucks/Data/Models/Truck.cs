using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Trucks.Data.Models.Enums;

namespace Trucks.Data.Models
{
    public class Truck
    {
        public Truck()
        {
            ClientsTrucks = new HashSet<ClientTruck>(); 
        }

        [Key]
        public int Id { get; set; }

        [RegularExpression(@"[A-Z]{2}[0-9]{4}[A-Z]{2}\")]
        public string RegistrationNumber { get; set; } = null!;

        [StringLength(17)]
        public string VinNumber { get; set; } = null!;

        [Range(950, 1420)]
        public int TankCapacity  { get; set; }

        [Range(5000, 29000)]
        public int CargoCapacity  { get; set; }

        [Required]
        public CategoryType CategoryType { get; set; }

        [Required]
        public MakeType MakeType { get; set; }

        [Required]
        [ForeignKey(nameof(Despatcher))]
        public int DespatcherId  { get; set; } 

        public virtual Despatcher Despatcher { get; set; } = null!;

        public virtual ICollection<ClientTruck> ClientsTrucks { get; set; } = null!;
    }
}
