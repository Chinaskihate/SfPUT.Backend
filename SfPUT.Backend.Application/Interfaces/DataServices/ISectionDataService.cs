using SfPUT.Backend.Domain.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SfPUT.Backend.Application.Interfaces.DataServices
{
    public interface ISectionDataService : IDataService<Section>
    {
        Task<IQueryable<Section>> GetByName(string name);
    }
}
