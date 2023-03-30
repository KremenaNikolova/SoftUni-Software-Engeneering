using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VaporStore.Data.Models.Enums;

namespace VaporStore.Data.Models
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }

        public PurchaseType Type { get; set; }

        [Required]
        public string ProductKey { get; set; } = null!;

        public DateTime Date { get; set; }

        [ForeignKey(nameof(Card))]
        public int CardId { get; set; }

        [Required]
        public virtual Card Card { get; set; } = null!;

        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }

        [Required]
        public virtual Game Game { get; set; } = null!;
    }
}
