using Library.Models;

namespace Library.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<AllBooksViewModel>> GetAllBooksAsync();

        Task<IEnumerable<MineBookViewModel>> GetMineBooksAsync(string id);

        Task AddBookAsync(AddBookViewModel viewModel);

        Task <IEnumerable<CategoryViewModel>> GetCategoriesAsync();

        Task<BookViewModel?> GetBookByIdAsync(int id);

        Task AddBookToCollectionAsync(string userId, BookViewModel bookModel);
    }
}
