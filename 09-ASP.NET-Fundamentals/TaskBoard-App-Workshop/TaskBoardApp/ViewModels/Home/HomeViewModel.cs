namespace TaskBoardApp.ViewModels.Home
{
    public class HomeViewModel
    {
        public int AllTasksCount { get; init; }

        public List<HomeBoardModel> BoardsWithTasksCount { get; set; } = null!;

        public int UserTasksCount { get; set; }
    }
}
