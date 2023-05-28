using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Social1.Models;
using Social1.Repositories;
using Social1.ViewModel;
using System.Collections.Generic;

namespace Social1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserRepositories use;
        private readonly IMapper mapper;
        public AppUserController(IAppUserRepositories user, IMapper mapper)
        {
            use = user;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<AppUserVM>> Getuser()
        {
            return await use.Get();
        }
        [HttpPost]
        public async Task<ActionResult<AppUserVM>> Postuser([FromBody] AppUserVM user)
        {
            await use.Create(user);
            return Ok(user);

        }
        [HttpPut]
        public async Task<ActionResult> Putuser( [FromBody] UserVMP user)
        {
            if (user.Id == 0)
            {

                throw new ArgumentException("Invalid User Id");
            }
            
            
                await use.Update(user);
                return Ok(user);
          
           
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> Getuser(long id)
        {
            return await use.Get(id);
        }
        [HttpDelete ("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var us = await use.Get(id);
        
            if (us == null)
                return NotFound();

            await use.Delete(us.Id);
            return Ok(us);

        }
       
        }
    }

