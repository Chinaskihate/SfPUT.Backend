using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SfPUT.Backend.Domain.Models;

namespace SfPUT.Backend.Application.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Comment> Comments { get; set; }

        DbSet<Post> Posts { get; set; }

        DbSet<Rate> Rates { get; set; }

        DbSet<Section> Sections { get; set; }

        DbSet<Tag> Tags { get; set; }

        DbSet<Like> Likes { get; set; }

        DbSet<ProposedSection> ProposedSections { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
