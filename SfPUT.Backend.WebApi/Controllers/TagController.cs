using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SfPUT.Backend.Application.Common.Tags;
using SfPUT.Backend.Application.Interfaces.Tags;
using SfPUT.Backend.Domain.Models;

namespace SfPUT.Backend.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    public class TagController : Controller
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService) => _tagService = tagService;

        /// <summary>
        /// Get all existing tags.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<TagVm>>> GetAll()
        {
            var tags = await _tagService.GetAllTags();
            return Ok(tags);
        }

        [HttpGet("GetByName")]
        public async Task<ActionResult<IEnumerable<TagVm>>> GetByName(string name)
        {
            var tags = await _tagService.GetTagsByName(name);
            return Ok(tags);
        }

        [HttpPost("CreateTag")]
        public async Task<ActionResult<Guid>> CreateTag(string name)
        {
            var id = await _tagService.CreateTag(name);
            return Ok(id);
        }
    }
}
