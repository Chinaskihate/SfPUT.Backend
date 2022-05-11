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
    public class TagDataService : ITagDataService
    {
        private readonly IAppDbContext _dbContext;

        public TagDataService(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Tag> Create(Tag entity)
        {
            var createdTag = await _dbContext.Tags.AddAsync(entity);
            await _dbContext.SaveChangesAsync(CancellationToken.None);

            return createdTag.Entity;
        }

        public async Task<IQueryable<Tag>> GetAll()
        {
            return _dbContext.Tags.AsQueryable();
        }

        public async Task<Tag> Get(Guid id)
        {
            return await _dbContext.Tags.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Tag> Update(Guid id, Tag entity)
        {
            entity.Id = id;
            _dbContext.Tags.Update(entity);
            await _dbContext.SaveChangesAsync(CancellationToken.None);
            return entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _dbContext.Tags.FirstOrDefaultAsync(x => x.Id == id);
            _dbContext.Tags.Remove(entity);
            await _dbContext.SaveChangesAsync(CancellationToken.None);
            return true;
        }

        public async Task<IQueryable<Tag>> GetByName(string name)
        {
            if (name == null)
            {
                return await GetAll();
            }
            return _dbContext.Tags.Where(t => t.Name.Contains(name));
        }
    }
}
