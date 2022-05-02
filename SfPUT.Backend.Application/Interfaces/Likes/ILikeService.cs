using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SfPUT.Backend.Application.Common.Likes;
using SfPUT.Backend.Domain.Models;

namespace SfPUT.Backend.Application.Interfaces.Likes
{
    public interface ILikeService
    {
        Task<bool> LikePost(LikePostDto dto, Guid userId);

        Task<IEnumerable<Like>> GetPostLikes(Guid postId);

        Task<IEnumerable<Like>> GetUserLikes(Guid userId);
    }
}
