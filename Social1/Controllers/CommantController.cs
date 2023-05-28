using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Social1.Models;
using Social1.Repositories;
using Social1.ViewModel;
using System.Runtime.Intrinsics.X86;

namespace Social1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommantController : ControllerBase
    {
        private readonly ICommantRepositories com;

        public CommantController(ICommantRepositories commant)
        {
            com = commant;

        }
        [HttpGet]
        public async Task<IEnumerable<CommantVM>> GetCommant()
        {
            return await com.Get();
        }

        [HttpPost]
        public async Task<ActionResult<CommantVM>> Postuser( [FromBody] CommantVM comma)
        {
            await com.Create(comma);
             return Ok(comma);

        }
        [HttpPut]
        public async Task<ActionResult> Putuser( [FromBody] CommantVMP commant)
        {
            if ( commant.Id==0)
            {
                return BadRequest();
            }
            await com.Update(commant);
            return Ok(commant);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Commant>> Getuser(long id)
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
