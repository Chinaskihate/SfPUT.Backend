using System;
using System.Linq;
using System.Threading.Tasks;
using SfPUT.Backend.Domain.Models;

namespace SfPUT.Backend.Application.Interfaces.DataServices
{
    public interface IPostDataService : IDataService<Post>
    {
        Task<IQueryable<Post>> GetUserPosts(Guid id);

        Task<IQueryable<Post>> GetByTitle(string name);
    }
}
