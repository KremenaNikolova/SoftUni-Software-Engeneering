using Forum.Data.Models;

namespace Forum.Data.Seeding
{
    internal class PostSeeder
    {
        internal Post[] GeneratePost()
        {
            ICollection<Post> posts = new HashSet<Post>();
            Post currPost;

            currPost = new Post()
            {
                Title = "My first post",
                Content = "My first post will be about performing CRUD operations in MVC. It's so much fun!"
            };
            posts.Add(currPost);

            currPost = new Post()
            {
                Title = "My second post",
                Content = "This is my second post. CRUD operations in MVC are getting more and more interesting!"
            };
            posts.Add(currPost);

            currPost = new Post()
            {
                Title = "My third post",
                Content = "Hello there! I'm getting better and better with the CRUD operations in MVC. Stay tuned!"
            };
            posts.Add(currPost);

            return posts.ToArray();

        }
    }
}
