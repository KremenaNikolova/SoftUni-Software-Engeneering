using Forum.Services.Interfaces;
using Forum.ViewModels.Post;
using Microsoft.AspNetCore.Mvc;
using Forum.Common;

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

            return RedirectToAction("All", "Post");
        }

        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                PostFormModel post = await this.postService.GetForEditByIdAsync(id);

                return View(post);
            }
            catch(Exception)
            {
                return this.RedirectToAction("All", "Post");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, PostFormModel editModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editModel);
            }

            try
            {
                await this.postService.EditByIdAsync(id, editModel);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, ErrorMessages.InvalidUpdateAction);

                return View(editModel);
            }

            return RedirectToAction("All", "Post");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await this.postService.DeleteByIdAsync(id);
            }
            catch(Exception) { }

            return RedirectToAction("All", "Post");
        }

    }
}
