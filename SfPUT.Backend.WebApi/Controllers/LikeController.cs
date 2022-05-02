using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SfPUT.Backend.Application.Common.Likes;
using SfPUT.Backend.Application.Interfaces.Likes;
using System.Threading.Tasks;

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

        [HttpPut("LikePost")]
        public async Task<ActionResult<bool>> LikePost([FromBody] LikePostDto dto)
        {
            var res = await _likeService.LikePost(dto, UserId);
            return res;
        }
    }
}
