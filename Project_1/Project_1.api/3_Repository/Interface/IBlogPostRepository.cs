using Project_1.api.Model;
using System.Collections.Generic;

namespace Project_1.api.Repository.Interface
{
    public interface IBlogPostRepository
    {
        IEnumerable<BlogPost> GetAllPosts();
        BlogPost GetPostById(int id);
        void AddPost(BlogPost post);
        void UpdatePost(BlogPost post);
        void DeletePost(int id);
    }
}
