using System;
using System.Threading.Tasks;
using SfPUT.Backend.Domain.Models;

namespace SfPUT.Backend.Application.Interfaces.DataServices
{
    public interface ILikeDataService : IDataService<Like>
    {
        Task<Like> GetLike(Guid postId, Guid userId);
    }
}
