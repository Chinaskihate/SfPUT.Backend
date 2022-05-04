using SfPUT.Backend.Application.Common.Posts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SfPUT.Backend.Application.Interfaces.Posts
{
    public interface IPostService
    {
        Task<Guid> CreatePost(CreatePostDto dto, Guid userId, string username);

        Task<bool> DeletePost(Guid postId, Guid userId);

        Task<bool> UpdatePost(UpdatePostDto dto, Guid userId);

        Task<IEnumerable<PostVm>> GetPosts(GetPostDto dto);

        Task<IEnumerable<PostVm>> GetCommentedPosts(Guid userId);

        Task<IEnumerable<PostVm>> GetRatedPosts(Guid userId);

        Task<IEnumerable<PostVm>> GetUserPosts(Guid userId);

        Task<IEnumerable<PostVm>> GetLikedPosts(Guid userId);
    }
}
