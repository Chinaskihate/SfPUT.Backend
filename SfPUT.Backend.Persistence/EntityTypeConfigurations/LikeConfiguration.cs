using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SfPUT.Backend.Domain.Models;

namespace SfPUT.Backend.Persistence.EntityTypeConfigurations
{
    public class LikeConfiguration : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.HasKey(like => like.Id);
            builder.HasIndex(like => like.Id).IsUnique();
            builder.HasIndex(like => like.PostId);
            builder.HasIndex(like => like.UserId);
        }
    }
}
