using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SfPUT.Backend.Application.Common.Tags;
using SfPUT.Backend.Application.Interfaces.DataServices;
using SfPUT.Backend.Application.Interfaces.Tags;
using SfPUT.Backend.Domain.Models;

namespace SfPUT.Backend.Application.Services.Tags
{
    public class TagService : ITagService
    {
        private readonly ITagDataService _tagDataService;
        private readonly IMapper _mapper;

        public TagService(ITagDataService tagDataService, IMapper mapper)
        {
            _tagDataService = tagDataService;
            _mapper = mapper;
        }
        
        public async Task<Guid> CreateTag(string name)
        {
            var tags = await _tagDataService.GetByName(name);
            if (tags.Any())
            {
                return Guid.Empty;
            }

            var newTag = new Tag()
            {
                Id = Guid.NewGuid(),
                Name = name
            };

            var creationResult = await _tagDataService.Create(newTag);
            return creationResult.Id;
        }

        public async Task<IEnumerable<TagVm>> GetAllTags()
        {
            return (await _tagDataService.GetAll())
                .Select(t => _mapper.Map<TagVm>(t));
        }

        public async Task<IEnumerable<TagVm>> GetTagsByName(string name)
        {
            return (await _tagDataService.GetByName(name))
                .Select(t => _mapper.Map<TagVm>(t));
        }

        public async Task<bool> DeleteTag(Guid id)
        {
            return await _tagDataService.Delete(id);
        }

        public async Task<IEnumerable<Tag>> ConvertTagVmsToTags(IEnumerable<TagVm> tagVms)
        {
            var tags = tagVms.Select(vm => _mapper.Map<Tag>(vm));
            var allTags = await _tagDataService.GetAll();
            return allTags.Intersect(tags);
        }
    }
}
