using Microsoft.AspNetCore.Mvc;
using Project_1.api.Model;
using Project_1.api.Services.Interface;

namespace Project_1.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly IBlogPostService _service;

        public BlogPostController(IBlogPostService service)
        {
            _service = service;
        }

        // GET: api/BlogPost
        [HttpGet]
        public ActionResult<IEnumerable<BlogPost>> GetAllPosts()
        {
            return Ok(_service.GetAllPosts());
        }

        // GET: api/BlogPost/{id}
        [HttpGet("{id}")]
        public ActionResult<BlogPost> GetPostById(int id)
        {
            var post = _service.GetPostById(id);
            if (post == null) return NotFound();
            return Ok(post);
        }

        // POST: api/BlogPost
        [HttpPost]
        public ActionResult AddPost([FromBody] BlogPost post)
        {
            _service.AddPost(post);
            // Returns 201 Created with the route: GET api/BlogPost/{id}
            return CreatedAtAction(nameof(GetPostById), new { id = post.Id }, post);
        }

        // PUT: api/BlogPost/{id}
        [HttpPut("{id}")]
        public ActionResult UpdatePost(int id, [FromBody] BlogPost post)
        {
            if (id != post.Id) return BadRequest("Mismatched BlogPost ID in route vs body.");

            _service.UpdatePost(post);
            return NoContent();
        }

        // DELETE: api/BlogPost/{id}
        [HttpDelete("{id}")]
        public ActionResult DeletePost(int id)
        {
            _service.DeletePost(id);
            return NoContent();
        }
    }
}
