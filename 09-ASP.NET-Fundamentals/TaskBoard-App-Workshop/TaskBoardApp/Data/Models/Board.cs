using System.ComponentModel.DataAnnotations;

using static TaskBoardApp.Data.DataConstans.Board;

namespace TaskBoardApp.Data.Models
{
    public class Board
    {
        public Board()
        {
            Tasks = new HashSet<Task>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(BoardMaxName)]
        [MinLength(BoardMinName)]
        public string Name { get; set; } = null!;

        public ICollection<Task>? Tasks { get; set; }
    }
}
