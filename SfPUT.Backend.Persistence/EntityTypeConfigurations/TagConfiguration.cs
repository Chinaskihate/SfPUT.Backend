using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SfPUT.Backend.Domain.Models;

namespace SfPUT.Backend.Persistence.EntityTypeConfigurations
{
    public class TagConfiguration:IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(tag => tag.Id);
            builder.HasIndex(tag => tag.Id).IsUnique();
            builder.Property(tag => tag.Name).HasMaxLength(50);
        }
    }
}
