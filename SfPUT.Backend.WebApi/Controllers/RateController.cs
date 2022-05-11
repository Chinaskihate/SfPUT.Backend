using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SfPUT.Backend.Application.Common.Rates;
using SfPUT.Backend.Application.Interfaces.Rates;

namespace SfPUT.Backend.WebApi.Controllers
{
    [ApiVersionNeutral]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    public class RateController : BaseController
    {
        private readonly IRateService _rateService;

        public RateController(IRateService rateService)
        {
            _rateService = rateService;
        }

        /// <summary>
        /// Rates the post.
        /// </summary>
        /// <param name="dto">RatePostDto object.</param>
        /// <returns>True if post was rated, otherwise false.</returns>
        /// <response code="201">Success.</response>
        /// <response code="401">If the user if unauthorized.</response>
        [HttpPost("RatePost")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<bool>> RatePost([FromBody] RatePostDto dto)
        {
            var res = await _rateService.RatePost(dto, UserId);
            return Ok(res);
        }

        [HttpGet("GetUserRating")]
        public async Task<ActionResult<double?>> GetUserRating()
        {
            var res = await _rateService.GetUserRating(UserId);
            return Ok(res);
        }
    }
}
