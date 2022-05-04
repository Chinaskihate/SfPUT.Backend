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
            // builder.Property(comment => comment.User).IsRequired();
            // builder.Property(comment => comment.Post).IsRequired();
            builder.OwnsOne(comment => comment.User);
            builder.OwnsOne(comment => comment.Info);
        }
    }
}
