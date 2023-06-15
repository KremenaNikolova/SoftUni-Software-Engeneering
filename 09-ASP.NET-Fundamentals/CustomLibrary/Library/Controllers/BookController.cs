using Library.Contracts;
using Library.Models.BookViewModels;
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

        public async Task<IActionResult> All(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                var showBooks = await bookService.GetBooksAsync();

                return View(showBooks);
            }

            var book = await bookService
                .SearchBookAsync(keyword);

            return View(book);
        }

        public async Task<IActionResult> Mine()
        {
            string userId = GetUserId();

            var showMyBooks = await bookService.GetMyBooksAsync(userId);
            
            return View(showMyBooks);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await bookService.GetCategoriesAsync();

            AddNewBookViewModel newBook = new AddNewBookViewModel()
            {
                Categories = categories
            };

            return View(newBook);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddNewBookViewModel newBookModel)
        {
            if(!ModelState.IsValid)
            {
                return View(newBookModel);
            }

            try
            {
                await bookService.AddNewBookAsync(newBookModel);
            }
            catch
            {
                BadRequest();
            }

            return RedirectToAction("All", "Book");
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(BookFormViewModel bookModel)
        {
            var userId = GetUserId();
            var book = await bookService.GetBookByIdAsync(bookModel.Id);

            if(book == null)
            {
                return RedirectToAction("All", "Book");
            }

            try
            {
                await bookService.AddToMyBooks(userId, book.Id);
            }
            catch
            {
                BadRequest();
            }

            return RedirectToAction("All", "Book");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(BookFormViewModel bookModel)
        {
            var userId = GetUserId();
            var book = await bookService.GetBookByIdAsync(bookModel.Id);

            if (book == null)
            {
                return RedirectToAction("Mine", "Book");
            }

            try
            {
                await bookService.RemoveFromMyBooks(userId, book.Id);
            }
            catch
            {
                BadRequest();
            }

            return RedirectToAction("Mine", "Book");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            AddNewBookViewModel? book = await bookService.GetBookByIdForEditAsync(id);

            if(book == null)
            {
                return RedirectToAction("All", "Book");
            }

            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AddNewBookViewModel bookModel)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            await bookService.EditBookAsync(id, bookModel);

            return RedirectToAction("All", "Book");
        }

        public async Task<IActionResult> SortByName()
        {
            var sortedBooks = await bookService.SortBooksByTitleAsync();

            return View(sortedBooks);
        }

        public async Task<IActionResult> SortByRating()
        {
            var sortedBooks = await bookService.SortBooksByRatingAsync();

            return View(sortedBooks);
        }

        public async Task<IActionResult> SortByCategory()
        {
            var sortedBooks = await bookService.SortBooksByCategoryAsync();

            return View(sortedBooks);
        }

        public async Task<IActionResult> SortByNewest()
        {
            var sortedBooks = await bookService.SortBooksByIdDescendingAsync();

            return View(sortedBooks);
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
