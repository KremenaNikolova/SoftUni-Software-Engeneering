using Text_Splitter_App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Text_Splitter_App.ViewModels;

namespace Text_Splitter_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(TextViewModel textModel)
        {
            return View(textModel);
        }

        [HttpPost]
        public IActionResult Split(TextViewModel textModel)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Index", textModel);
            }

            var splitText = textModel
                .Text
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            textModel.SplitText = string.Join(Environment.NewLine, splitText);

            return this.RedirectToAction("Index", textModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}