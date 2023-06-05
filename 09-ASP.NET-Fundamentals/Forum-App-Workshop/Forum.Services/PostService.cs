using Forum.Data;
using Forum.Data.Models;
using Forum.Services.Interfaces;
using Forum.ViewModels.Post;
using Microsoft.EntityFrameworkCore;

namespace Forum.Services
{
    public class PostService : IPostService
    {
        private readonly ForumDbContext dbContext;

        public PostService(ForumDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<IEnumerable<PostListViewModel>> ListAllAsync()
        {
            IEnumerable<PostListViewModel> allPosts = await dbContext
                .Posts
                .Select (p => new PostListViewModel
                {
                    Id = p.Id.ToString(),
                    Title = p.Title,
                    Content = p.Content
                })
                .ToArrayAsync();

            return allPosts;    
        }


        public async Task AddPostAsync(PostFormModel model)
        {
            Post newPost = new Post()
            {
                Title = model.Title,
                Content = model.Content
            };

            await dbContext.Posts.AddAsync(newPost);
            await dbContext.SaveChangesAsync();
        }

        
        public async Task<PostFormModel> GetForEditByIdAsync(string id)
        {
            Post postToEdit = await this.dbContext
                .Posts
                .FirstAsync(p => p.Id.ToString() == id);

            return new PostFormModel()
            {
                Title = postToEdit.Title,
                Content = postToEdit.Content
            };

        }

        public async Task EditByIdAsync(string id, PostFormModel model)
        {
            Post postToEdit = await this.dbContext
                .Posts
                .FirstAsync(p=>p.Id.ToString()==id);

            postToEdit.Title = model.Title;
            postToEdit.Content = model.Content;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(string id)
        {
            Post postForDelete = await this.dbContext
                .Posts
                .FirstAsync(p => p.Id.ToString() == id);

            this.dbContext.Posts.Remove(postForDelete);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
