using System;
using System.Linq;
using System.Threading.Tasks;
using SfPUT.Backend.Domain.Models;

namespace SfPUT.Backend.Application.Interfaces.DataServices
{
    public interface IRateDataService : IDataService<Rate>
    {
        Task<IQueryable<Rate>> GetByUserId(Guid userId);
    }
}
