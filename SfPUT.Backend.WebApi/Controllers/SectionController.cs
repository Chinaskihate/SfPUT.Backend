using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SfPUT.Backend.Application.Common.Sections;
using SfPUT.Backend.Application.Interfaces.Sections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

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

        /// <summary>
        /// Get all existing sections.
        /// </summary>
        /// <returns>List of SectionVm.</returns>
        /// <response code="201">Success.</response>
        /// <response code="401">If the user if unauthorized.</response>
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<SectionVm>>> GetAllSections()
        {
            var res = await _sectionService.GetAllSectionVms();
            return Ok(res);
        }

        /// <summary>
        /// Get sections by part of their name.
        /// </summary>
        /// <param name="name">Part of name.</param>
        /// <returns>List of SectionVm.</returns>
        /// <response code="201">Success.</response>
        /// <response code="401">If the user if unauthorized.</response>
        [HttpGet("GetByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<SectionVm>>> GetSectionsByName(string name)
        {
            var res = await _sectionService.GetSectionVmsByName(name);
            return Ok(res);
        }

        /// <summary>
        /// Creates new section for admins to review.
        /// </summary>
        /// <param name="name">Name of new section.</param>
        /// <returns>True if section was sent for review, otherwise false.</returns>
        /// <response code="201">Success.</response>
        /// <response code="401">If the user if unauthorized.</response>
        [HttpPost("CreateSection")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<bool>> CreateSection(string name)
        {
            var res = await _sectionService.CreateSection(name);
            return Ok(res);
        }
        
        [HttpDelete("DeleteSection")]
        public async Task<ActionResult<bool>> DeleteSection(Guid id)
        {
            if (Username != "admin")
            {
                return Forbid(id.ToString());
            }
            var res = await _sectionService.DeleteSection(id);
            return Ok(res);
        }
        
        // [Authorize(Roles = "Admin")]
        [HttpPost("ApplySection")]
        // TODO: add roles to application.
        public async Task<ActionResult<Guid>> ApplySection(Guid proposedSectionId)
        {
            if (Username != "admin")
            {
                return Forbid();
            }
            var res = await _sectionService.ApplySection(UserId, proposedSectionId);
            return Ok(res);
        }
        
        [HttpGet("GetProposed")]
        // TODO: add roles to application.
        public async Task<ActionResult<Guid>> GetProposedSections()
        {
            var res = await _sectionService.GetProposedSections();
            return Ok(res);
        }
    }
}
