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
    public class PostDataService : IPostDataService
    {
        private readonly IAppDbContext _dbContext;

        public PostDataService(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Post> Create(Post entity)
        {
            var createdComment = await _dbContext.Posts.AddAsync(entity);
            await _dbContext.SaveChangesAsync(CancellationToken.None);

            return createdComment.Entity;
        }

        public async Task<IQueryable<Post>> GetAll()
        {
            return GetFullPosts()
                .AsQueryable();
        }

        public async Task<Post> Get(Guid id)
        {
            return await GetFullPosts()
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Post> Update(Guid id, Post entity)
        {
            entity.Id = id;
            _dbContext.Posts.Update(entity);
            await _dbContext.SaveChangesAsync(CancellationToken.None);
            return entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _dbContext.Posts.FirstOrDefaultAsync(x => x.Id == id);
            _dbContext.Posts.Remove(entity);
            await _dbContext.SaveChangesAsync(CancellationToken.None);
            return true;
        }

        public async Task<IQueryable<Post>> GetUserPosts(Guid id)
        {
            return GetFullPosts().Where(p => p.User.Id == id);
        }

        public async Task<IQueryable<Post>> GetByTitle(string name)
        {
            return GetFullPosts().Where(p => p.Info.Title.Contains(name));
        }

        private IQueryable<Post> GetFullPosts() => _dbContext.Posts
            .Include(post => post.Tags)
            .Include(post => post.Comments)
            .Include(post => post.Rates)
            .Include(post => post.Section);
    }
}
