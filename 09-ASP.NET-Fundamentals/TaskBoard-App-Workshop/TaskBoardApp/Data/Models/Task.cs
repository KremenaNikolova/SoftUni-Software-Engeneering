using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TaskBoardApp.Data.DataConstans.Task;

namespace TaskBoardApp.Data.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(TaskMaxTitle)]
        [MinLength(TaskMinTitle)]
        [Required]
        public string Title { get; set; } = null!;

        [MaxLength(TaskMaxDescription)]
        [MinLength(TaskMinDescription)]
        [Required]
        public string Description { get; set; } = null!;

        public DateTime CreateOn { get; set; }

        public int BoardId { get; set; }

        [ForeignKey(nameof(BoardId))]
        public Board? Board { get; set; }

        [Required]
        public string OwnerId { get; set; } = null!;

        [ForeignKey(nameof(OwnerId))]
        public IdentityUser Owner { get; set; } = null!;
    }
}
