using Social1.Models;
using Social1.ViewModel;

namespace Social1.Repositories
{
    public interface IAppUserRepositories
    {
        Task<IEnumerable<AppUserVM>> Get();
        Task<AppUserVM> Create(AppUserVM user);
        Task Update(UserVMP user);
     
        Task<AppUser> Get(long id);
        Task Delete(long? id);
    }
}
