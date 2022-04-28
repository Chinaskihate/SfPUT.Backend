using Microsoft.EntityFrameworkCore;
using SfPUT.Backend.Application.Interfaces;
using SfPUT.Backend.Domain.Models;
using SfPUT.Backend.Persistence.EntityTypeConfigurations;

namespace SfPUT.Backend.Persistence
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<ProposedSection> ProposedSections { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SectionConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new RateConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new LikeConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
