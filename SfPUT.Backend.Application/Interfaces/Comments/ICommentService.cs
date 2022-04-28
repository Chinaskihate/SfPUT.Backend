using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SfPUT.Backend.Domain.Models;

namespace SfPUT.Backend.Application.Interfaces.Comments
{
    public interface ICommentService
    {
        Task<Guid> CreateComment(string content, Guid userId, Guid postId);

        Task<bool> DeleteComment(Guid commentId, Guid userId);

        Task<bool> UpdateComment(string content, Guid commentId, Guid userId);

        Task<IEnumerable<Comment>> GetUserComments(Guid userId);
    }
}
