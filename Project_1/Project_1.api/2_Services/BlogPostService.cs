using Project_1.api.Model;
using Project_1.api.Repository.Interface;
using Project_1.api.Services.Interface;
using System.Collections.Generic;

namespace Project_1.api.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IBlogPostRepository _repository;

        public BlogPostService(IBlogPostRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<BlogPost> GetAllPosts()
        {
            return _repository.GetAllPosts();
        }

        public BlogPost GetPostById(int id)
        {
            return _repository.GetPostById(id);
        }

        public void AddPost(BlogPost post)
        {
            _repository.AddPost(post);
        }

        public void UpdatePost(BlogPost post)
        {
            _repository.UpdatePost(post);
        }

        public void DeletePost(int id)
        {
            _repository.DeletePost(id);
        }
    }
}
