using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Social1.Models;
using Social1.ViewModel;

namespace Social1.Repositories
{
    public class PostRepositories : IPostRepositories
    {
        private readonly SocialMediaContext con;
        private readonly IMapper mapper;

        public PostRepositories(SocialMediaContext context, IMapper mapp)
        {
            con = context;
            mapper = mapp;

        }
        public async Task<PostVM> Create(PostVM pos)
        {
            var posts = mapper.Map<Post>(pos);
            con.Posts.Add(posts);
            await con.SaveChangesAsync();
            return pos;
        }

        public async Task Delete(long? id)
        {
            var cond = await con.Posts.FindAsync(id);
            con.Posts.Remove(cond);
            await con.SaveChangesAsync();
        }

        public async Task<IEnumerable<PostVM>> Get()
        {
            var comm = await con.Posts.ToListAsync();

            return mapper.Map<List<PostVM>>(comm);
        }

        public async Task<Post> Get(long id)
        {
            var comm = await con.Posts.FindAsync(id);
            return mapper.Map<Post>(comm);
        }

        public  async Task Update(PostVMP com)
        {
            var conup = mapper.Map<Post>(com);
            con.Entry(conup).State = EntityState.Modified;
            await con.SaveChangesAsync();

        }
    }
}
