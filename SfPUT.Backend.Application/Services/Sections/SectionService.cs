using AutoMapper;
using SfPUT.Backend.Application.Common.Sections;
using SfPUT.Backend.Application.Interfaces.DataServices;
using SfPUT.Backend.Application.Interfaces.Sections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SfPUT.Backend.Application.Common.Exceptions;
using SfPUT.Backend.Domain.Models;

namespace SfPUT.Backend.Application.Services.Sections
{
    public class SectionService : ISectionService
    {
        private readonly ISectionDataService _sectionDataService;
        private readonly IProposedSectionDataService _proposedSectionDataService;
        private readonly IMapper _mapper;

        public SectionService(ISectionDataService sectionDataService,
            IProposedSectionDataService proposedSectionDataService,
            IMapper mapper)
        {
            _sectionDataService = sectionDataService;
            _proposedSectionDataService = proposedSectionDataService;
            _mapper = mapper;
        }

        public async Task<Section> Get(Guid id)
        {
            var section = await _sectionDataService.Get(id);
            if (section == null)
            {
                throw new SectionNotFoundException(id);
            }

            return section;
        }

        public async Task<bool> CreateSection(string name)
        {
            var section = await _sectionDataService.GetByName(name.ToLower());
            if (section.Any())
            {
                return false;
            }

            var proposedSections = await _proposedSectionDataService.GetByName(name.ToLower());
            if (proposedSections.Any())
            {
                return false;
            }

            await _proposedSectionDataService.Create(new ProposedSection()
            {
                Id = Guid.NewGuid(),
                Name = name
            });
            return true;
        }

        public async Task<IEnumerable<SectionVm>> GetAllSectionVms()
        {
            return (await _sectionDataService.GetAll())
                .Select(s => _mapper.Map<SectionVm>(s));
        }

        public async Task<IEnumerable<SectionVm>> GetSectionVmsByName(string name)
        {
            return (await _sectionDataService.GetByName(name))
                .Select(s => _mapper.Map<SectionVm>(s));
        }

        public async Task<bool> DeleteSection(Guid id)
        {
            return await _sectionDataService.Delete(id);
        }

        public async Task<Guid> ApplySection(Guid adminId, Guid proposedSectionId)
        {
            var proposedSection = await _proposedSectionDataService.Get(proposedSectionId);
            var section = await _sectionDataService.GetByName(proposedSection.Name);
            if (section.Any())
            {
                return Guid.Empty;
            }

            await _sectionDataService.Create(new Section()
            {
                Id = proposedSection.Id,
                Name = proposedSection.Name,
                AdminId = adminId
            });

            return proposedSection.Id;
        }
    }
}
