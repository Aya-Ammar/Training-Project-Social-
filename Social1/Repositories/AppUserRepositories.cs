using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Social1.Models;
using Social1.ViewModel;
namespace Social1.Repositories
{
    public class AppUserRepositories : IAppUserRepositories
    {
        private readonly SocialMediaContext con;
        private readonly IMapper mapper;

        public AppUserRepositories(SocialMediaContext context, IMapper mapp)
        {
            con = context;
            mapper = mapp;
         
        }

        public async Task<IEnumerable<AppUserVM>> Get()
        {
           var user= await con.AppUsers
                 .Include(i => i.Commants).Include(i => i.Posts).ThenInclude(c => c.Commants).ToListAsync();
                         return mapper.Map<List<AppUserVM>>(user);
            
        }
       

        public async Task<AppUserVM> Create(AppUserVM user)
        {
            var us=mapper.Map<AppUser>(user);
            con.AppUsers.Add(us);
            await con.SaveChangesAsync();
            return user;
        }

        public async Task Update(UserVMP user)
        {
            var use=mapper.Map<AppUser>(user);
                con.Entry(use).State = EntityState.Modified;
                await con.SaveChangesAsync();
        }
        public async Task Delete(long? id)
        {
            var userdelete = await con.AppUsers.FindAsync(id);
            con.AppUsers.Remove(userdelete);
            await con.SaveChangesAsync();
        }
        public async Task<AppUser> Get(long id)
        {
          return await con.AppUsers.Include(i => i.Commants).Include(i => i.Posts).ThenInclude(c => c.Commants).Where(u => u.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
