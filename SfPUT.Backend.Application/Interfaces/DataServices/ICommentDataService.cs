using System;
using System.Linq;
using System.Threading.Tasks;
using SfPUT.Backend.Domain.Models;

namespace SfPUT.Backend.Application.Interfaces.DataServices
{
    public interface ICommentDataService : IDataService<Comment>
    {
        Task<Comment> Get(Guid userId, Guid postId);

        Task<IQueryable<Comment>> GetUserComments(Guid userId);
    }
}
