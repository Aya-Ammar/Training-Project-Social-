using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Social1.Models;
using Social1.Repositories;
using Social1.ViewModel;

namespace Social1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepositories com;

        public PostController(IPostRepositories commant)
        {
            com = commant;

        }
        [HttpGet]
        public async Task<IEnumerable<PostVM>> GetPost()
        {
            return await com.Get();
        }

        [HttpPost]
        public async Task<ActionResult<PostVM>> Postuser([FromBody] PostVM pos)
        {
            await com.Create(pos);
            return Ok(pos);

        }
        [HttpPut]
        public async Task<ActionResult> Putuser( [FromBody] PostVMP post)
        {
            if (post.Id == 0)
            {
                return BadRequest();
            }
            await com.Update(post);
            return Ok(post);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> Getuser(long id)
        {
            return await com.Get(id);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var us = await com.Get(id);

            if (us == null)
                return NotFound();

            await com.Delete(us.Id);
            return Ok(us);

        }

    }
}

