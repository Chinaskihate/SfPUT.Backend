using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SfPUT.Backend.Application.Interfaces.DataServices;
using SfPUT.Backend.Application.Interfaces.Likes;
using SfPUT.Backend.Domain.Models;

namespace SfPUT.Backend.Application.Services.Likes
{
    public class LikeService : ILikeService
    {
        private readonly ILikeDataService _likeDataService;

        public LikeService(ILikeDataService likeDataService)
        {
            _likeDataService = likeDataService;
        }

        public async Task<bool> LikePost(Guid postId, Guid userId, bool isLiked = true)
        {
            var like = await _likeDataService.GetLike(postId, userId);
            switch (isLiked)
            {
                case true when like == null:
                    await _likeDataService.Create(new Like()
                    {
                        Id = Guid.NewGuid(),
                        PostId = postId,
                        UserId = userId
                    });
                    return true;
                case false when like != null:
                    return await _likeDataService.Delete(like.Id);
                default:
                    return true;
            }
        }
    }
}
