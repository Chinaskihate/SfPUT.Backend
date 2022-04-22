using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SfPUT.Backend.Domain.Models;

namespace SfPUT.Backend.Persistence.EntityTypeConfigurations
{
    public class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.HasKey(section => section.Id);
            builder.HasIndex(section => section.Id).IsUnique();
            builder.Property(section => section.Name).HasMaxLength(100);
        }
    }
}
