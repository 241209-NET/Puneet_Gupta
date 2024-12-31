using Microsoft.AspNetCore.Mvc;
using Project_1.api.Model;
using Project_1.api.Services.Interface;
using System.Collections.Generic;

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

        [HttpGet]
        public ActionResult<IEnumerable<BlogPost>> GetAllPosts()
        {
            return Ok(_service.GetAllPosts());
        }

        [HttpGet("{id}")]
        public ActionResult<BlogPost> GetPostById(int id)
        {
            var post = _service.GetPostById(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpPost]
        public ActionResult AddPost(BlogPost post)
        {
            _service.AddPost(post);
            return CreatedAtAction(nameof(GetPostById), new { id = post.Id }, post);
        }

        [HttpPut("{id}")]
        public ActionResult UpdatePost(int id, BlogPost post)
        {
            if (id != post.Id)
            {
                return BadRequest();
            }

            _service.UpdatePost(post);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePost(int id)
        {
            _service.DeletePost(id);
            return NoContent();
        }
    }
}
