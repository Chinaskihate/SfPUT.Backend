using SfPUT.Backend.Application.Interfaces;
using SfPUT.Backend.Application.Interfaces.DataServices;
using SfPUT.Backend.Domain.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SfPUT.Backend.Persistence.DataServices
{
    public class RateDataService : IRateDataService
    {
        private readonly IAppDbContext _dbContext;

        public RateDataService(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Rate> Create(Rate entity)
        {
            var createdRate = await _dbContext.Rates.AddAsync(entity);
            await _dbContext.SaveChangesAsync(CancellationToken.None);

            return createdRate.Entity;
        }

        public async Task<IQueryable<Rate>> GetAll()
        {
            return _dbContext.Rates.AsQueryable();
        }

        public async Task<Rate> Get(Guid id)
        {
            return await _dbContext.Rates.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Rate> Update(Guid id, Rate entity)
        {
            entity.Id = id;
            _dbContext.Rates.Update(entity);
            await _dbContext.SaveChangesAsync(CancellationToken.None);
            return entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _dbContext.Rates.FirstOrDefaultAsync(x => x.Id == id);
            _dbContext.Rates.Remove(entity);
            await _dbContext.SaveChangesAsync(CancellationToken.None);
            return true;
        }

        public async Task<IQueryable<Rate>> GetByUserId(Guid userId)
        {
            return _dbContext.Rates.Where(r => r.UserId == userId);
        }
    }
}
