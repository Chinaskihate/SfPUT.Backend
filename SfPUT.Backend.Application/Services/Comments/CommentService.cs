using SfPUT.Backend.Application.Common.Comments;
using SfPUT.Backend.Application.Interfaces.Comments;
using SfPUT.Backend.Application.Interfaces.DataServices;
using SfPUT.Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SfPUT.Backend.Application.Services.Comments
{
    public class CommentService : ICommentService
    {
        private readonly ICommentDataService _commentDataService;
        private readonly IPostDataService _postDataService;

        public CommentService(ICommentDataService commentDataService, 
            IPostDataService postDataService)
        {
            _commentDataService = commentDataService;
            _postDataService = postDataService;
        }
        
        public async Task<Guid> CreateComment(CreateCommentDto dto, Guid userId, string username)
        {
            var comment = await _commentDataService.Get(userId: userId, postId: dto.PostId);
            if (comment != null)
            {
                return Guid.Empty;
            }

            var user = new User()
            {
                Id = userId,
                Username = username
            };
            var post = await _postDataService.Get(dto.PostId);
            var newComment = new Comment()
            {
                Id = Guid.NewGuid(),
                Info = new CommentInfo()
                {
                    Content = dto.Content,
                    CreationTime = DateTime.Now,
                    LastEditTime = DateTime.Now
                },
                User = user,
                Post = post
            };
            var res = await _commentDataService.Create(newComment);
            return res.Id;
        }

        public async Task<bool> DeleteComment(Guid commentId, Guid userId)
        {
            // TODO#5: check what happens on commend delete.
            var comment = await _commentDataService.Get(commentId);
            if (comment == null && comment.User.Id != userId)
            {
                return false;
            }

            return await _commentDataService.Delete(commentId);
        }

        public async Task<bool> UpdateComment(UpdateCommentDto dto, Guid userId)
        {
            var comment = await _commentDataService.Get(dto.CommentId);
            if (comment == null || 
                comment.User.Id != userId ||
                (DateTime.Now - comment.Info.CreationTime).TotalDays >= 1)
            {
                return false;
            }

            comment.Info.Content = dto.Content;
            comment.Info.LastEditTime = DateTime.Now;

            await _commentDataService.Update(comment.Id, comment);
            return true;
        }

        public async Task<IEnumerable<Comment>> GetUserComments(Guid userId)
        {
            return await _commentDataService.GetUserComments(userId);
        }
    }
}
