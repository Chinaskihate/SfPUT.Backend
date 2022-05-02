using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SfPUT.Backend.Application.Common.Sections;
using SfPUT.Backend.Application.Interfaces.Sections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SfPUT.Backend.WebApi.Controllers
{
    [ApiVersionNeutral]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    public class SectionController : BaseController
    {
        private readonly ISectionService _sectionService;

        public SectionController(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<SectionVm>>> GetAllSections()
        {
            var res = await _sectionService.GetAllSectionVms();
            return Ok(res);
        }

        [HttpGet("GetByName")]
        public async Task<ActionResult<IEnumerable<SectionVm>>> GetSectionsByName(string name)
        {
            var res = await _sectionService.GetSectionVmsByName(name);
            return Ok(res);
        }

        [HttpPost("CreateSection")]
        public async Task<ActionResult<bool>> CreateSection(string name)
        {
            var res = await _sectionService.CreateSection(name);
            return Ok(res);
        }

        [HttpDelete("DeleteSection")]
        // TODO: add roles to application.
        public async Task<ActionResult<bool>> DeleteSection(Guid id)
        {
            var res = await _sectionService.DeleteSection(id);
            return Ok(res);
        }

        [HttpPost("ApplySection")]
        // TODO: add roles to application.
        public async Task<ActionResult<Guid>> ApplySection(Guid proposedSectionId)
        {
            var res = await _sectionService.ApplySection(UserId, proposedSectionId);
            return Ok(res);
        }
    }
}
