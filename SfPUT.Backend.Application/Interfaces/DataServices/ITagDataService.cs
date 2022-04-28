using SfPUT.Backend.Domain.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SfPUT.Backend.Application.Interfaces.DataServices
{
    public interface ITagDataService : IDataService<Tag>
    {
        Task<IQueryable<Tag>> GetByName(string name);
    }
}
