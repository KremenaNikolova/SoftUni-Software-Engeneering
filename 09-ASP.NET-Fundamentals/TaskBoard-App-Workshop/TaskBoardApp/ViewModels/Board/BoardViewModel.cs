using TaskBoardApp.ViewModels.Task;

namespace TaskBoardApp.ViewModels.Board
{
    public class BoardViewModel
    {
        public BoardViewModel()
        {
            Tasks = new HashSet<TaskViewModel>();
        }

        public int Id { get; init; }

        public string Name { get; set; } = null!;

        public IEnumerable<TaskViewModel> Tasks { get; set; }
    }
}
