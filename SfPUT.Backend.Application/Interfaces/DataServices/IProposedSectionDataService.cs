using System.Linq;
using System.Threading.Tasks;
using SfPUT.Backend.Domain.Models;

namespace SfPUT.Backend.Application.Interfaces.DataServices
{
    public interface IProposedSectionDataService : IDataService<ProposedSection>
    {
        Task<IQueryable<ProposedSection>> GetByName(string name);
    }
}
