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
    public class SectionDataService: ISectionDataService
    {
        private readonly IAppDbContext _dbContext;

        public SectionDataService(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Section> Create(Section entity)
        {
            var createdSection = await _dbContext.Sections.AddAsync(entity);
            await _dbContext.SaveChangesAsync(CancellationToken.None);

            return createdSection.Entity;
        }

        public async Task<IQueryable<Section>> GetAll()
        {
            return _dbContext.Sections.AsQueryable();
        }

        public async Task<Section> Get(Guid id)
        {
            return await _dbContext.Sections.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Section> Update(Guid id, Section entity)
        {
            entity.Id = id;
            _dbContext.Sections.Update(entity);
            await _dbContext.SaveChangesAsync(CancellationToken.None);
            return entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _dbContext.Sections.FirstOrDefaultAsync(x => x.Id == id);
            _dbContext.Sections.Remove(entity);
            await _dbContext.SaveChangesAsync(CancellationToken.None);
            return true;
        }

        public async Task<IQueryable<Section>> GetByName(string name)
        {
            return _dbContext.Sections.Where(s => s.Name.Contains(name));
        }
    }
}
