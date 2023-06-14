using Microsoft.EntityFrameworkCore;

using Library.Contracts;
using Library.Data;
using Library.Data.Models;
using Library.Models.BookViewModels;
using Library.Models.CategoryViewModels;
using System.Net;

namespace Library.Service
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext dbContext;

        public BookService(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddNewBookAsync(AddNewBookViewModel newBookModel)
        {
            var newBook = new Book()
            {
                Title = newBookModel.Title,
                Author = newBookModel.Author,
                Description = newBookModel.Description,
                ImageUrl = newBookModel.Url,
                Rating = newBookModel.Rating,
                CategoryId = newBookModel.CategoryId
            };


            await dbContext.AddAsync(newBook);
            await dbContext.SaveChangesAsync();
        }

        public async Task AddToMyBooks(string userId, int bookId)
        {
            var book = await dbContext
                .Books
                .FirstOrDefaultAsync(b => b.Id == bookId);

            bool isAlreadyAdded = book!
                .UsersBooks
                .Any(ub => ub.CollectorId == userId);

            if (!isAlreadyAdded)
            {
                book.UsersBooks.Add(new IdentityUserBook()
                {
                    CollectorId = userId,
                    BookId = bookId
                });

                await dbContext.SaveChangesAsync();
            }
        }


        public async Task RemoveFromMyBooks(string userId, int bookId)
        {
            var book = await dbContext
                .Books
                .FirstOrDefaultAsync(b => b.Id == bookId);

            if (book != null)
            {
                var bookForRemove = new IdentityUserBook()
                {
                    BookId = book.Id,
                    CollectorId = userId
                };

                dbContext.UsersBooks.Remove(bookForRemove);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<BookFormViewModel?> GetBookByIdAsync(int bookId)
        {
            var book = await dbContext
                .Books
                .Where(b => b.Id == bookId)
                .Select(b => new BookFormViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Description = b.Description,
                    ImageUrl = b.ImageUrl,
                    Rating = b.Rating,
                    Category = b.Category.Name
                })
                .FirstOrDefaultAsync();

            return book;
        }

        public async Task<IEnumerable<BookFormViewModel>> GetBooksAsync()
        {
            var allBookdView = await dbContext
                .Books
                .Select(b => new BookFormViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                    Rating = b.Rating,
                    Category = b.Category.Name
                })
                .ToListAsync();

            return allBookdView;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetCategoriesAsync()
        {
            var categories = await dbContext
                .Categories
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();

            return categories;
        }

        public async Task<IEnumerable<BookFormViewModel>> GetMyBooksAsync(string userId)
        {
            var userBooks = await dbContext
                .UsersBooks
                .Where(ub => ub.CollectorId == userId)
                .Select(ub => new BookFormViewModel()
                {
                    Id = ub.Book!.Id,
                    Title = ub.Book.Title,
                    Author = ub.Book.Author,
                    Description = ub.Book.Description,
                    ImageUrl = ub.Book.ImageUrl,
                    Category = ub.Book.Category.Name
                })
                .ToListAsync();

            return userBooks;
        }

        public async Task EditBookAsync(int bookId, AddNewBookViewModel viewModel)
        {
            var currBook = await dbContext
                .Books
                .FindAsync(bookId);

            if(currBook != null)
            {
                currBook.Title = viewModel.Title;
                currBook.Author = viewModel.Author;
                currBook.Description = viewModel.Description;
                currBook.ImageUrl = viewModel.Url;
                currBook.Rating = viewModel.Rating;
                currBook.CategoryId = viewModel.CategoryId;
            }

            await dbContext.SaveChangesAsync();
        }

        public async Task<AddNewBookViewModel?> GetBookByIdForEditAsync(int bookId)
        {
            var categories = await dbContext
                .Categories
                .Select(c=> new CategoryViewModel()
                {
                    Id=c.Id,
                    Name = c.Name,
                })
                .ToListAsync();

            var book = await dbContext
                 .Books
                 .Where(b => b.Id == bookId)
                 .Select(b => new AddNewBookViewModel()
                 {
                     Title = b.Title,
                     Author = b.Author,
                     Description = b.Description,
                     Url = b.ImageUrl,
                     Rating = b.Rating,
                     CategoryId = b.CategoryId,
                     Categories = categories
                 })
                 .FirstOrDefaultAsync();

            return book;
        }

        public async Task<IEnumerable<BookFormViewModel>> SearchBookAsync(string keyword)
        {
            var productSearch = await dbContext
                .Books
                .Where(b=> b.Title.ToLower().Contains(keyword.ToLower()))
                .Select(b=> new BookFormViewModel()
                {
                    Id = b.Id,
                    Title=b.Title,
                    Author=b.Author,
                    Description=b.Description,
                    ImageUrl = b.ImageUrl,
                    Rating = b.Rating,
                    Category = b.Category.Name
                })
                .ToArrayAsync();

            return productSearch;
        }

        public async Task<IEnumerable<BookFormViewModel>> SortBooksByTitleAsync()
        {
            var books = await dbContext
                .Books
                .Select(b => new BookFormViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Description = b.Description,
                    ImageUrl= b.ImageUrl,
                    Rating = b.Rating,
                    Category = b.Category.Name
                })
                .OrderBy(b=>b.Title)
                .ToListAsync();

            return books;
        }
    }
}
