using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using TaskBoardApp.Data;
using TaskBoardApp.ViewModels.Board;
using TaskBoardApp.ViewModels.Task;

namespace TaskBoardApp.Controllers
{
    public class BoardController : Controller
    {
        private readonly TaskBoardDbContext dbContex;

        public BoardController(TaskBoardDbContext dbContex)
        {
            this.dbContex = dbContex;
        }

        public async Task<IActionResult> All()
        {
            var boards = await dbContex
                .Boards
                .Select(b => new BoardViewModel()
                {
                    Id = b.Id,
                    Name = b.Name,
                    Tasks = b.Tasks!
                        .Where(t => t.BoardId == b.Id)
                        .Select(t => new TaskViewModel()
                        {
                            Id = t.Id,
                            Title = t.Title,
                            Description = t.Description,
                            Owner = t.Owner.UserName
                        })
                })
                .ToListAsync();

            return View(boards);
        }
    }
}
