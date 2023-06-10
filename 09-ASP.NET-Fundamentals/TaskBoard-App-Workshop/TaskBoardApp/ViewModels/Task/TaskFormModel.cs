using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Data.DataConstans.Task;

namespace TaskBoardApp.ViewModels.Task
{
    public class TaskFormModel
    {
        public TaskFormModel()
        {
            Boards = new HashSet<TaskBoardModel>();
        }

        [Required]
        [StringLength(TaskMaxTitle, MinimumLength = TaskMinTitle, ErrorMessage = "Title should be at least {2} charackters long.")]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(TaskMaxDescription, MinimumLength = TaskMinDescription, ErrorMessage = "Description should be at last {2} characters long.")]
        public string Description { get; set; } = null!;

        [Display(Name = "Board")]
        public int BoardId { get; set; }

        public IEnumerable<TaskBoardModel> Boards { get; set; } = null!;
    }
}
