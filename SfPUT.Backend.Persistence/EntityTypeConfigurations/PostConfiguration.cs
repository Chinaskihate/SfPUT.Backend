using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SfPUT.Backend.Domain.Models;

namespace SfPUT.Backend.Persistence.EntityTypeConfigurations
{
    public class PostConfiguration:IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(post => post.Id);
            builder.HasIndex(post => post.Id).IsUnique();
            builder.OwnsOne(post => post.Info);
            builder.OwnsOne(post => post.User);
            // TODO: fix
            // builder.Property(post => post.Info.Title).HasMaxLength(100);
            // builder.Property(post => post.Section).IsRequired();
        }
    }
}
