using SfPUT.Backend.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SfPUT.Backend.Application.Interfaces.DataServices
{
    public interface IDataService<T> where T : DomainObject
    {
        Task<T> Create(T entity);

        Task<IQueryable<T>> GetAll();

        Task<T> Get(Guid id);

        Task<T> Update(Guid id, T entity);

        Task<bool> Delete(Guid id);
    }
}
