using System;
using System.Threading.Tasks;
using SfPUT.Backend.Domain.Models;

namespace SfPUT.Backend.Application.Interfaces.DataServices
{
    public interface ICommentDataService : IDataService<Comment>
    {
        Task<Comment> Get(Guid userId, Guid postId);
    }
}
