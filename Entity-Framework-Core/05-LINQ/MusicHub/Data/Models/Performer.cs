namespace MusicHub.Data.Models;

using System.ComponentModel.DataAnnotations;

public class Performer
{
    public Performer()
    {
        PerformerSongs = new HashSet<SongPerformer>();
    }

    [Key]
    public int Id { get; set; }

    [MaxLength(20)]
    public string FirstName { get; set; } = null!;

    [MaxLength(20)]
    public string LastName { get; set; } = null!;

    public int Age { get; set; }

    public decimal NetWorth { get; set; }

    public ICollection<SongPerformer> PerformerSongs { get; set; }
}
