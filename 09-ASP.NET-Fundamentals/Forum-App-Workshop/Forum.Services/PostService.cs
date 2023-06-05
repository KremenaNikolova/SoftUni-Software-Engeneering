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
    }
}
