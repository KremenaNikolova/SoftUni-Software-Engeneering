using System.ComponentModel.DataAnnotations.Schema;

namespace Boardgames.Data.Models
{
    public class BoardgameSeller
    {
        [ForeignKey(nameof(Boardgame))]
        public int BoardgameId { get; set; }

        public virtual Boardgame Boardgame { get; set; } = null!;

        [ForeignKey(nameof(Seller))]
        public int SellerId { get; set; }

        public virtual Seller Seller { get; set; } = null!;
    }
}
