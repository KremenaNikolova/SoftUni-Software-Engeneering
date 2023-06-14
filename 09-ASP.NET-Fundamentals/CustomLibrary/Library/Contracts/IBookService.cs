using Library.Models.BookViewModels;
using Library.Models.CategoryViewModels;

namespace Library.Contracts
{
    public interface IBookService
    {
        public Task AddNewBookAsync(AddNewBookViewModel newBookModel);

        public Task AddToMyBooks(string userId, int bookId);

        public Task EditBookAsync(int id, AddNewBookViewModel viewModel);

        public Task<IEnumerable<BookFormViewModel>> GetBooksAsync();

        public Task<BookFormViewModel?> GetBookByIdAsync(int bookId);

        public Task<IEnumerable<BookFormViewModel>> GetMyBooksAsync(string UserId);

        public Task<AddNewBookViewModel?> GetBookByIdForEditAsync(int bookId);

        public Task<IEnumerable<CategoryViewModel>> GetCategoriesAsync();

        public Task RemoveFromMyBooks(string userId, int bookId);

        public Task<IEnumerable<BookFormViewModel>> SearchBookAsync(string keyword);

        public Task<IEnumerable<BookFormViewModel>> SortBooksByTitleAsync();



    }
}
