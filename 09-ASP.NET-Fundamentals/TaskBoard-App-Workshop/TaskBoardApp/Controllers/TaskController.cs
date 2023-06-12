using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TaskBoardApp.Data;
using TaskBoardApp.ViewModels.Task;
using Task = TaskBoardApp.Data.Models.Task;

namespace TaskBoardApp.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private readonly TaskBoardDbContext dbContext;

        public TaskController(TaskBoardDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Create()
        {
            TaskFormModel taskModel = new TaskFormModel()
            {
                Boards = GetBoards()
            };

            return View(taskModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskFormModel taskModel)
        {
            if(!GetBoards().Any(b=>b.Id == taskModel.BoardId))
            {
                ModelState.AddModelError(nameof(taskModel.BoardId), "Board does not exist.");
            }

            string currendUserId = GetUserId();

            if (!ModelState.IsValid)
            {
                taskModel.Boards = GetBoards();
                return View(taskModel);
            }

            Task task = new Task()
            {
                Title = taskModel.Title,
                Description = taskModel.Description,
                CreateOn = DateTime.Now,
                BoardId = taskModel.BoardId,
                OwnerId = currendUserId
            };

            await dbContext.Tasks.AddAsync(task);
            await dbContext.SaveChangesAsync();

            var boards = dbContext.Boards;

            return RedirectToAction("All", "Board");
        }


        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var task = await dbContext
                .Tasks
                .Where(t => t.Id == id)
                .Select(t => new TaskDetailsViewModel
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    CreateOn = t.CreateOn.ToString("dd/MM/yyyy HH:mm"),
                    Board = t.Board.Name,
                    Owner = t.Owner.UserName
                })
                .FirstOrDefaultAsync();

            if (task == null)
            {
                return BadRequest();
            }

            return View(task);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var task = await dbContext
                .Tasks
                .FindAsync(id);

            if(task == null)
            {
                return BadRequest();
            }

            string currendUserId = GetUserId();
            if (currendUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            TaskFormModel taskModel = new TaskFormModel
            {
                Title = task.Title,
                Description = task.Description,
                BoardId = task.BoardId,
                Boards = GetBoards()
            };

            return View(taskModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, TaskFormModel taskModel)
        {
            var task = await dbContext.Tasks.FindAsync(id);

            if (task == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();
            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            if(!ModelState.IsValid)
            {
                taskModel.Boards = GetBoards();

                return View(taskModel);
            }

            task.Title = taskModel.Title;
            task.Description = taskModel.Description;
            task.BoardId = taskModel.BoardId;

            await dbContext.SaveChangesAsync();
            return RedirectToAction("All", "Board");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var task = await dbContext.Tasks.FindAsync(id);

            if (task == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();
            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            TaskViewModel taskModel = new TaskViewModel()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description
            };

            return View(taskModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, TaskViewModel taskModel)
        {
            var task = await dbContext.Tasks.FindAsync(id);

            if(task == null)
            {
                return BadRequest();
            }

            var currUser = GetUserId();
            if(currUser != task.OwnerId)
            {
                return Unauthorized();
            }

            dbContext.Tasks.Remove(task);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("All", "Board");
        }


        private IEnumerable<TaskBoardModel> GetBoards()
        {
            return dbContext.Boards
                .Select(b => new TaskBoardModel()
                {
                    Id = b.Id,
                    Name = b.Name,
                })
                .ToList();
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
