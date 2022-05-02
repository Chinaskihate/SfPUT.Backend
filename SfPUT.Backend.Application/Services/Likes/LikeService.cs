using SfPUT.Backend.Application.Common.Likes;
using SfPUT.Backend.Application.Interfaces.DataServices;
using SfPUT.Backend.Application.Interfaces.Likes;
using SfPUT.Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SfPUT.Backend.Application.Services.Likes
{
    public class LikeService : ILikeService
    {
        private readonly ILikeDataService _likeDataService;

        public LikeService(ILikeDataService likeDataService)
        {
            _likeDataService = likeDataService;
        }

        public async Task<bool> LikePost(LikePostDto dto, Guid userId)
        {
            var like = await _likeDataService.GetLike(dto.PostId, userId);
            switch (dto.IsLiked)
            {
                case true when like == null:
                    await _likeDataService.Create(new Like()
                    {
                        Id = Guid.NewGuid(),
                        PostId = dto.PostId,
                        UserId = userId
                    });
                    return true;
                case false when like != null:
                    return await _likeDataService.Delete(like.Id);
                default:
                    return true;
            }
        }

        public async Task<IEnumerable<Like>> GetPostLikes(Guid postId)
        {
            return await _likeDataService.GetPostLikes(postId);
        }

        public async Task<IEnumerable<Like>> GetUserLikes(Guid userId)
        {
            return await _likeDataService.GetUserLikes(userId);
        }
    }
}
