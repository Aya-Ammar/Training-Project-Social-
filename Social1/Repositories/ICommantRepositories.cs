using Social1.Models;
using Social1.ViewModel;

namespace Social1.Repositories
{
    public interface ICommantRepositories
    {
        Task<IEnumerable<CommantVM>> Get();
        Task<CommantVM> Create(CommantVM com);
        Task Update(CommantVMP com);

        Task<Commant> Get(long id);
        Task Delete(long? id);
    }
}
