using SfPUT.Backend.Application.Common.Posts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SfPUT.Backend.Application.Interfaces.Posts
{
    public interface IPostService
    {
        Task<Guid> CreatePost(Guid userId,
                            Guid sectionId,
                            string title,
                            string sellerLink,
                            string description,
                            IEnumerable<Guid> tagsIds);

        Task<bool> DeletePost(Guid postId, Guid userId);

        // TODO#1: change many params to one class. 
        Task<bool> UpdatePost(Guid postId,
                            Guid userId,
                            string sellerLink,
                            string description,
                            IEnumerable<Guid> tagsIds);

        // TODO#2: change many params to one class.
        Task<IEnumerable<PostVm>> GetPosts(string title,
                                        IEnumerable<Guid> tagsIds,
                                        double minRate,
                                        Guid sectionId,
                                        DateTime creationTime);

        Task<IEnumerable<PostVm>> GetCommentedPosts(Guid userId);

        Task<IEnumerable<PostVm>> GetRatedPosts(Guid userId);

        Task<IEnumerable<PostVm>> GetUserPosts(Guid userId);

        Task<IEnumerable<PostVm>> GetLikedPosts(Guid userId);
    }
}
