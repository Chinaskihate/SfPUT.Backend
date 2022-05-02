using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost("RatePost")]
        public async Task<ActionResult<bool>> RatePost([FromBody] RatePostDto dto)
        {
            var res = await _rateService.RatePost(dto, UserId);
            return Ok(res);
        }
    }
}
