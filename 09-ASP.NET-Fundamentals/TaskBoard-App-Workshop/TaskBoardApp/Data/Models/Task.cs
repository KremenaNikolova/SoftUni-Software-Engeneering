using System.ComponentModel.DataAnnotations;

using static TaskBoardApp.Data.DataConstans;

namespace TaskBoardApp.Data.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [StringLength(DataConstans.)]
        public string Title { get; set; } = null!;
    }
}
