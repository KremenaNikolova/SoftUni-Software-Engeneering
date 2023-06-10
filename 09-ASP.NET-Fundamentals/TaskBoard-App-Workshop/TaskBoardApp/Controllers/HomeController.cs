using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using TaskBoardApp.Data;
using TaskBoardApp.ViewModels;
using TaskBoardApp.ViewModels.Home;

namespace TaskBoardApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly TaskBoardDbContext dbContext;

        public HomeController(TaskBoardDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var taskBoards = dbContext
                .Boards
                .Select(b => b.Name)
                .Distinct();

            var tasksCounts = new List<HomeBoardModel> ();
            foreach (var boardName in taskBoards)
            {
                var tasksInBoard = dbContext
                    .Tasks
                    .Where(t=>t.Board.Name == boardName).Count();

                tasksCounts.Add(new HomeBoardModel()
                {
                    BoardName = boardName,
                    TasksCount = tasksInBoard
                });
            }

            int userTasksCount = -1;

            if (User.Identity.IsAuthenticated)
            {
                var curredntUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                userTasksCount = dbContext
                    .Tasks
                    .Where(t=>t.OwnerId == curredntUserId)
                    .Count();
            }

            var homeModel = new HomeViewModel()
            {
                AllTasksCount = dbContext.Tasks.Count(),
                BoardsWithTasksCount = tasksCounts,
                UserTasksCount = userTasksCount
            };

            return View(homeModel);
        }
    }
}