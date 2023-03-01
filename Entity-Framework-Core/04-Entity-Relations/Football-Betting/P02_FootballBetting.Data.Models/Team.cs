using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models;

public class Team
{
    public Team()
    {
        HomeGames = new HashSet<Game>();
        AwayGames= new HashSet<Game>();
        Players= new HashSet<Player>();
    }  

    [Key]
    public int TeamId { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;

    [MaxLength(50)]
    public string? LogoUrl { get; set; }

    [Required]
    [MaxLength(10)]
    public string Initials { get; set; } = null!;

    public decimal Budget { get; set; }

    [ForeignKey(nameof(PrimaryKitColor))]
    public int PrimaryKitColorId { get; set; }
    public virtual Color PrimaryKitColor { get; set; } = null!;

    [ForeignKey(nameof(SecondaryKitColor))]
    public int SecondaryKitColorId { get; set; }
    public virtual Color SecondaryKitColor { get; set; } = null!;

    [ForeignKey(nameof(Town))]
    public int TownId { get; set; }
    public virtual Town Town { get; set; } = null!;

    public virtual ICollection<Game> HomeGames { get; set; }

    public virtual ICollection<Game> AwayGames { get; set; }

    public virtual ICollection<Player> Players { get; set; }

}