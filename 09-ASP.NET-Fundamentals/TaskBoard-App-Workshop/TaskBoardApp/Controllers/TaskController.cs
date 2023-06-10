using Microsoft.AspNetCore.Mvc;

namespace TaskBoardApp.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
