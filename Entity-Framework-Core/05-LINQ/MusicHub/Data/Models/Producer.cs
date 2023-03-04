namespace MusicHub.Data.Models;

using System.ComponentModel.DataAnnotations;

public class Producer
{
    public Producer()
    {
        Albums = new HashSet<Album>();
    }

    [Key]
    public int Id { get; set; }

    [MaxLength(30)]
    public string Name { get; set; } = null!;

    public string? Pseudonym { get; set; }

    public string? PhoneNumber { get; set; }

    public ICollection<Album> Albums { get; set; }
}
