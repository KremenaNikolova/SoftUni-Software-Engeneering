using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Library.Contracts;
using Library.Data;
using Library.Data.Models;
using Library.Models;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext dbContext;

        public BookService(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddBookAsync(AddBookViewModel viewModel)
        {
            var book = new Book()
            {
                Title = viewModel.Title,
                Author = viewModel.Author,
                Description = viewModel.Description,
                ImageUrl = viewModel.Url,
                Rating = viewModel.Rating,
                CategoryId = viewModel.CategoryId,
            };


            await dbContext.AddAsync(book);
            await dbContext.SaveChangesAsync();

        }

        public async Task AddBookToCollectionAsync(string userId, BookViewModel bookModel)
        {
            bool alreadyAdded = await dbContext
                .UserBooks
                .AnyAsync(ub => ub.CollectorId == userId && ub.BookId == bookModel.Id);

            if (!alreadyAdded)
            {
                var book = new IdentityUserBook()
                {
                    BookId = bookModel.Id,
                    CollectorId = userId,
                };

                await dbContext.UserBooks.AddAsync(book);
                await dbContext.SaveChangesAsync();
            }
                
        }

        public async Task<IEnumerable<AllBooksViewModel>> GetAllBooksAsync()
        {
            var books = await dbContext
                .Books
                .Select(book => new AllBooksViewModel()
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    ImageUrl = book.ImageUrl,
                    Rating = book.Rating,
                    Category = book.Category.Name,
                })
                .ToListAsync();

            return books;
        }

        public async Task<BookViewModel?> GetBookByIdAsync(int id)
        {
            var book = await dbContext
                .Books
                .Where(b=>b.Id == id)
                .Select(b=> new BookViewModel()
                {
                    Id=b.Id,
                    Title=b.Title,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                    Description = b.Description,
                    Rating = b.Rating,
                    CategoryId=b.Category.Id
                })
                .FirstOrDefaultAsync();

            return book;

        }

        public async Task<IEnumerable<CategoryViewModel>> GetCategoriesAsync()
        {
            var categories = await dbContext
                .Categories
                .Select(c=> new CategoryViewModel()
                {
                    Id =c.Id,
                    Name = c.Name,
                })
                .ToArrayAsync();

            return categories;
        }

        public async Task<IEnumerable<MineBookViewModel>> GetMineBooksAsync(string id)
        {
            var myBooks = await dbContext
                .UserBooks
                .Where(ub => ub.CollectorId == id)
                .Select(ub => new MineBookViewModel()
                {
                    Id = ub.Book!.Id,
                    Title = ub.Book.Title,
                    Author = ub.Book.Author,
                    ImageUrl = ub.Book.ImageUrl,
                    Description = ub.Book.Description,
                    Category = ub.Book.Category.Name
                })
                .ToListAsync();

            return myBooks;
        }
    }
}
