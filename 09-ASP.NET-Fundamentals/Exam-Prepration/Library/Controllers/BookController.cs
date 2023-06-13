using Library.Contracts;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Library.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public async Task<IActionResult> All()
        {
            var allBooks = await bookService.GetAllBooksAsync();

            return View(allBooks);
        }

        public async Task<IActionResult> Mine()
        {
            string userID = GetUserId();

            var myBooks = await bookService.GetMineBooksAsync(userID);

            return View(myBooks);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await bookService.GetCategoriesAsync();

            AddBookViewModel newBook = new AddBookViewModel()
            {
                Categories = categories
            };

            return View(newBook);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel bookModel)
        {
            if (!ModelState.IsValid)
            {
                return View(bookModel);
            }

            await bookService.AddBookAsync(bookModel);

            return RedirectToAction("All", "Book");
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(BookViewModel bookModel)
        {
            var book = await bookService
                .GetBookByIdAsync(bookModel.Id);

            if(book == null)
            {
                return RedirectToAction("All", "Book");
            }

            var userId = GetUserId();

            try
            {
                await bookService.AddBookToCollectionAsync(userId, bookModel);
            }
            catch
            {
                BadRequest();
            }

            return RedirectToAction("All", "Book");

        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(BookViewModel bookModel)
        {
            var book = await bookService
                .GetBookByIdAsync(bookModel.Id);

            if (book == null)
            {
                return RedirectToAction("Mine", "Book");
            }

            var userId = GetUserId();
            try
            {
                await bookService.RemoveBookFromCollectionAsync(userId, bookModel);
            }
            catch
            {
                BadRequest();
            }
            

            return RedirectToAction("Mine", "Book");
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
