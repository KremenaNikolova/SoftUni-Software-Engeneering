using Forum.ViewModels.Post;

namespace Forum.Services.Interfaces
{
    public interface IPostService
    {
        Task<IEnumerable<PostListViewModel>> ListAllAsync();

        Task AddPostAsync(PostFormModel model);

        Task<PostFormModel> GetForEditByIdAsync(string id);

        Task EditByIdAsync(string id,  PostFormModel model);

        Task DeleteByIdAsync(string id);
    }
}
