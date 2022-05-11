using SfPUT.Backend.Application.Common.Sections;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SfPUT.Backend.Domain.Models;

namespace SfPUT.Backend.Application.Interfaces.Sections
{
    public interface ISectionService
    {
        Task<IEnumerable<SectionVm>> GetAllSectionVms();

        Task<IEnumerable<SectionVm>> GetSectionVmsByName(string name);

        Task<Section> Get(Guid id);

        Task<IEnumerable<ProposedSection>> GetProposedSections();

        Task<bool> CreateSection(string name);

        Task<bool> DeleteSection(Guid id);

        Task<Guid> ApplySection(Guid adminId, Guid proposedSectionId);
    }
}
