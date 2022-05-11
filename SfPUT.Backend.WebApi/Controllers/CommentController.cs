using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SfPUT.Backend.Application.Common.Comments;
using SfPUT.Backend.Application.Interfaces.Comments;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

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

        /// <summary>
        /// Creates the comment.
        /// </summary>
        /// <param name="dto">CreateCommentDto object.</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success.</response>
        /// <response code="401">If the user if unauthorized.</response>
        [HttpPost("CreateComment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> CreateComment([FromBody] CreateCommentDto dto)
        {
            var res = await _commentService.CreateComment(dto, UserId, Username);
            return Ok(res);
        }

        /// <summary>
        /// Deletes the comment.
        /// </summary>
        /// <param name="commentId">Comment id.</param>
        /// <returns>True if comment deleted, otherwise false.</returns>
        /// <response code="201">Success.</response>
        /// <response code="401">If the user if unauthorized.</response>
        [HttpDelete("DeleteComment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<bool>> DeleteComment(Guid commentId)
        {
            var res = await _commentService.DeleteComment(commentId: commentId, userId: UserId);
            return Ok(res);
        }

        /// <summary>
        /// Updates the comment.
        /// </summary>
        /// <param name="dto">UpdateCommentDto object.</param>
        /// <returns>True if comment updated, otherwise false.</returns>
        /// <response code="201">Success.</response>
        /// <response code="401">If the user if unauthorized.</response>
        [HttpPut("UpdateComment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<bool>> UpdateComment([FromBody] UpdateCommentDto dto)
        {
            var res = await _commentService.UpdateComment(dto, UserId);
            return res;
        }
    }
}
