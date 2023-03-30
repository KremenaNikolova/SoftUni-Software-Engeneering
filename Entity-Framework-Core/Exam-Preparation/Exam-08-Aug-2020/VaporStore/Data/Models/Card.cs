using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VaporStore.Data.Models.Enums;

namespace VaporStore.Data.Models
{
    public class Card
    {
        public Card()
        {
            Purchases = new HashSet<Purchase>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Number { get; set; } = null!;

        [Required]
        public string Cvc { get; set; } = null!;

        public CardType Type { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        [Required]
        public virtual User User { get; set; } = null!;

        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
