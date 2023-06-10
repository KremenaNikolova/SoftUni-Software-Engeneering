namespace TaskBoardApp.ViewModels.Task
{
    public class TaskViewModel
    {
        public int Id { get; init; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Owner { get; set; } = null!;
    }
}
