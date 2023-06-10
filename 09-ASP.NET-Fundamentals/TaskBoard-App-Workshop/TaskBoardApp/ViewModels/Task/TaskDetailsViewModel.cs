namespace TaskBoardApp.ViewModels.Task
{
    public class TaskDetailsViewModel : TaskViewModel
    {
        public string CreateOn { get; set; } = null!;

        public string Board { get; set; } = null!;
    }
}
