using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SfPUT.Backend.Application.Common.Tags;
using SfPUT.Backend.Application.Interfaces.Tags;
using SfPUT.Backend.Domain.Models;

namespace SfPUT.Backend.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TagController : Controller
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService) => _tagService = tagService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TagVm>>> GetAll()
        {
            var tags = await _tagService.GetAllTags();
            return Ok(tags);
        }
    }
}
