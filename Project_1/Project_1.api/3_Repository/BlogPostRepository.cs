using Project_1.api.Data;
using Project_1.api.Model;
using Project_1.api.Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Project_1.api.Repository
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly SampleContext _context;

        public BlogPostRepository(SampleContext context)
        {
            _context = context;
        }

        public IEnumerable<BlogPost> GetAllPosts()
        {
            return _context.BlogPosts.ToList();
        }

        public BlogPost GetPostById(int id)
        {
            return _context.BlogPosts.FirstOrDefault(p => p.Id == id);
        }

        public void AddPost(BlogPost post)
        {
            _context.BlogPosts.Add(post);
            _context.SaveChanges();
        }

        public void UpdatePost(BlogPost post)
        {
            _context.BlogPosts.Update(post);
            _context.SaveChanges();
        }

        public void DeletePost(int id)
        {
            var post = _context.BlogPosts.Find(id);
            if (post != null)
            {
                _context.BlogPosts.Remove(post);
                _context.SaveChanges();
            }
        }
    }
}