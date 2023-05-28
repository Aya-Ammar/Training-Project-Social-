using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Social1.Models;
using Social1.ViewModel;

namespace Social1.Repositories
{
    public class CommantRepositories : ICommantRepositories
    {
        private readonly SocialMediaContext con;
        private readonly IMapper mapper;

        public CommantRepositories(SocialMediaContext context, IMapper mapp)
        {
            con = context;
            mapper = mapp;

        }
        public async Task<CommantVM> Create(CommantVM com)
        {
            var us = mapper.Map<Commant>(com);
            con.Commants.Add(us);
            await con.SaveChangesAsync();
            return com  ;
        }

        public async Task Delete(long? id)
        {
            var conde = await con.Commants.FindAsync(id);
            con.Commants.Remove(conde);
            await con.SaveChangesAsync();
        }

        public async Task<IEnumerable<CommantVM>> Get()
        {
            var comm= await con.Commants.ToListAsync();

            return mapper.Map<List<CommantVM>>(comm);
        }

        public  async Task<Commant> Get(long id)
        {
            var comm = await con.Commants.FindAsync(id);
            return mapper.Map<Commant>(comm);
        }

        public async Task Update(CommantVMP com)
        {
            var conup = mapper.Map<Commant>(com);
            con.Entry(conup).State = EntityState.Modified;
            await con.SaveChangesAsync();
        }
    }
}
