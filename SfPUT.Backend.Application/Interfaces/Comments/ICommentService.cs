using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SfPUT.Backend.Application.Common.Comments;
using SfPUT.Backend.Domain.Models;

namespace SfPUT.Backend.Application.Interfaces.Comments
{
    public interface ICommentService
    {
        Task<Guid> CreateComment(CreateCommentDto dto, Guid userId);

        Task<bool> DeleteComment(Guid commentId, Guid userId);

        Task<bool> UpdateComment(UpdateCommentDto dto, Guid userId);

        Task<IEnumerable<Comment>> GetUserComments(Guid userId);
    }
}
