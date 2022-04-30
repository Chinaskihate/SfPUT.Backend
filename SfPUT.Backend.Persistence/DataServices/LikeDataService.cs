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
    public class LikeDataService : ILikeDataService
    {
        private readonly IAppDbContext _dbContext;

        public LikeDataService(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Like> Create(Like entity)
        {
            var createdLike = await _dbContext.Likes.AddAsync(entity);
            await _dbContext.SaveChangesAsync(CancellationToken.None);

            return createdLike.Entity;
        }

        public async Task<IQueryable<Like>> GetAll()
        {
            return _dbContext.Likes.AsQueryable();
        }

        public async Task<Like> Get(Guid id)
        {
            return await _dbContext.Likes.FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<Like> Update(Guid id, Like entity)
        {
            entity.Id = id;
            _dbContext.Likes.Update(entity);
            await _dbContext.SaveChangesAsync(CancellationToken.None);
            return entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _dbContext.Likes.FirstOrDefaultAsync(x => x.Id == id);
            _dbContext.Likes.Remove(entity);
            await _dbContext.SaveChangesAsync(CancellationToken.None);
            return true;
        }

        public Task<Like> GetLike(Guid postId, Guid userId)
        {
            return _dbContext.Likes.FirstOrDefaultAsync(l => l.PostId == postId && l.UserId == userId);
        }

        public async Task<IQueryable<Like>> GetPostLikes(Guid postId)
        {
            return _dbContext.Likes.Where(l => l.PostId == postId);
        }

        public async Task<IQueryable<Like>> GetUserLikes(Guid userId)
        {
            return _dbContext.Likes.Where(l => l.UserId == userId);
        }
    }
}
