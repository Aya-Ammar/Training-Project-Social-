using Social1.Models;
using Social1.ViewModel;

namespace Social1.Repositories
{
    public interface IPostRepositories
    {
        Task<IEnumerable<PostVM>> Get();
        Task<PostVM> Create(PostVM com);
        Task Update(PostVMP com);

        Task<Post> Get(long id);
        Task Delete(long? id);
    }
}
