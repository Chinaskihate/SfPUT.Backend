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
    public class ProposedSectionDataService : IProposedSectionDataService
    {
        private readonly IAppDbContext _dbContext;

        public ProposedSectionDataService(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProposedSection> Create(ProposedSection entity)
        {
            var createdProposedSection = await _dbContext.ProposedSections.AddAsync(entity);
            await _dbContext.SaveChangesAsync(CancellationToken.None);

            return createdProposedSection.Entity;
        }

        public async Task<IQueryable<ProposedSection>> GetAll()
        {
            return _dbContext.ProposedSections.AsQueryable();
        }


        public async Task<ProposedSection> Get(Guid id)
        {
            return await _dbContext.ProposedSections.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ProposedSection> Update(Guid id, ProposedSection entity)
        {
            entity.Id = id;
            _dbContext.ProposedSections.Update(entity);
            await _dbContext.SaveChangesAsync(CancellationToken.None);
            return entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _dbContext.ProposedSections.FirstOrDefaultAsync(x => x.Id == id);
            _dbContext.ProposedSections.Remove(entity);
            await _dbContext.SaveChangesAsync(CancellationToken.None);
            return true;
        }

        public async Task<IQueryable<ProposedSection>> GetByName(string name)
        {
            return _dbContext.ProposedSections.Where(s => s.Name.Contains(name));
        }
    }
}
