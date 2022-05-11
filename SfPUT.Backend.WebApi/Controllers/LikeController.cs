using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SfPUT.Backend.Application.Common.Likes;
using SfPUT.Backend.Application.Interfaces.Likes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SfPUT.Backend.WebApi.Controllers
{
    [ApiVersionNeutral]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    public class LikeController : BaseController
    {
        private readonly ILikeService _likeService;

        public LikeController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        /// <summary>
        /// Likes the post.
        /// </summary>
        /// <param name="dto">LikePostDto object.</param>
        /// <returns>True if post was liked, otherwise false.</returns>
        /// <response code="201">Success.</response>
        /// <response code="401">If the user if unauthorized.</response>
        [HttpPut("LikePost")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<bool>> LikePost([FromBody] LikePostDto dto)
        {
            var res = await _likeService.LikePost(dto, UserId);
            return res;
        }
    }
}
