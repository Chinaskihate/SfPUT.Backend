using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SfPUT.Backend.Application.Common.Comments;
using SfPUT.Backend.Application.Interfaces.Comments;

namespace SfPUT.Backend.WebApi.Controllers
{
    [ApiVersionNeutral]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    public class  CommentController: BaseController
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost("CreateComment")]
        public async Task<ActionResult<Guid>> CreateComment([FromBody] CreateCommentDto dto)
        {
            var res = await _commentService.CreateComment(dto, UserId, Username);
            return Ok(res);
        }

        [HttpDelete("DeleteComment")]
        public async Task<ActionResult<bool>> DeleteComment(Guid commentId)
        {
            var res = await _commentService.DeleteComment(commentId: commentId, userId: UserId);
            return Ok(res);
        }

        [HttpPut("UpdateComment")]
        public async Task<ActionResult<bool>> UpdateComment([FromBody] UpdateCommentDto dto)
        {
            var res = await _commentService.UpdateComment(dto, UserId);
            return res;
        }
    }
}
