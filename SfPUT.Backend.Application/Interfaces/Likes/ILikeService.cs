using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SfPUT.Backend.Domain.Models;

namespace SfPUT.Backend.Application.Interfaces.Likes
{
    public interface ILikeService
    {
        Task<bool> LikePost(Guid postId, Guid userId, bool isLiked = true);

        Task<IEnumerable<Like>> GetPostLikes(Guid postId);

        Task<IEnumerable<Like>> GetUserLikes(Guid userId);
    }
}
