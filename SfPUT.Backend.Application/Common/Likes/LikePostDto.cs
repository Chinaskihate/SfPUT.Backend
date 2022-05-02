using System;

namespace SfPUT.Backend.Application.Common.Likes
{
    public class LikePostDto
    {
        public Guid PostId { get; set; }

        public bool IsLiked { get; set; } = true;
    }
}
