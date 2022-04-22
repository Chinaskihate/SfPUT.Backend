using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SfPUT.Backend.Domain.Models;

namespace SfPUT.Backend.Persistence.EntityTypeConfigurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(comment => comment.Id);
            builder.HasIndex(comment => comment.Id).IsUnique();
            builder.Property(comment => comment.UserId).IsRequired();
            builder.Property(comment => comment.Post).IsRequired();
        }
    }
}
