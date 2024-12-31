using Microsoft.EntityFrameworkCore;
using Project_1.api.Model;

namespace Project_1.api.Data
{
    public class SampleContext : DbContext
    {
        public SampleContext(DbContextOptions<SampleContext> options) : base(options) { }

        public DbSet<BlogPost> BlogPosts { get; set; }
    }
}
