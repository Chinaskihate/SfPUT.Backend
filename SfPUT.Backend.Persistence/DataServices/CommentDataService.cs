using SfPUT.Backend.Application.Interfaces.DataServices;
using SfPUT.Backend.Domain.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SfPUT.Backend.Application.Interfaces;

namespace SfPUT.Backend.Persistence.DataServices
{
    public class CommentDataService : ICommentDataService
    {
        private readonly IAppDbContext _dbContext;

        public CommentDataService(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Comment> Create(Comment entity)
        {
            var createdComment = await _dbContext.Comments.AddAsync(entity);
            await _dbContext.SaveChangesAsync(CancellationToken.None);

            return createdComment.Entity;
        }

        public async Task<IQueryable<Comment>> GetAll()
        {
            return _dbContext.Comments.AsQueryable();
        }

        public async Task<Comment> Get(Guid id)
        {
            return await _dbContext.Comments.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Comment> Update(Guid id, Comment entity)
        {
            entity.Id = id;
            _dbContext.Comments.Update(entity);
            await _dbContext.SaveChangesAsync(CancellationToken.None);
            return entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _dbContext.Comments.FirstOrDefaultAsync(x => x.Id == id);
            _dbContext.Comments.Remove(entity);
            await _dbContext.SaveChangesAsync(CancellationToken.None);
            return true;
        }

        public async Task<Comment> Get(Guid userId, Guid postId)
        {
            var entity = await _dbContext.Comments.FirstOrDefaultAsync(c => c.Id == postId && c.User.Id == userId);
            return entity;
        }

        public async Task<IQueryable<Comment>> GetUserComments(Guid userId)
        {
            var comments = _dbContext.Comments.Where(c => c.User.Id == userId);
            return comments;
        }
    }
}
