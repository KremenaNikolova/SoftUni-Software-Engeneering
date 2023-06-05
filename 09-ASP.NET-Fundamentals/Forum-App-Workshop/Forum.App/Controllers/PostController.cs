using Forum.Services.Interfaces;
using Forum.ViewModels.Post;
using Microsoft.AspNetCore.Mvc;
using Forum.Common;
using Forum.Common.Validations;

namespace Forum.App.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService = postService;
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<PostListViewModel> allPost = await postService.ListAllAsync();

            return View(allPost);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostFormModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }

            try
            {
                await this.postService.AddPostAsync(inputModel);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, ErrorMessages.InvalidAddAction);

                return View(inputModel);
            }

            return RedirectToAction("All");
        }
    }
}
