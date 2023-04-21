namespace MusicHub.Data.Models;

using System.ComponentModel.DataAnnotations;

public class Writer
{
    public Writer()
    {
        Songs = new HashSet<Song>();
    }

    [Key]
    public int Id { get; set; }

    [MaxLength(20)]
    public string Name { get; set; } = null!;

    public string? Pseudonym  { get; set; }

    public ICollection<Song> Songs { get; set; }
}
