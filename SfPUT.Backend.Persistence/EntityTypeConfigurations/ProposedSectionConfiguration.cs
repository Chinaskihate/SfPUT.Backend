using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SfPUT.Backend.Domain.Models;

namespace SfPUT.Backend.Persistence.EntityTypeConfigurations
{
    public class ProposedSectionConfiguration : IEntityTypeConfiguration<ProposedSection>
    {
        public void Configure(EntityTypeBuilder<ProposedSection> builder)
        {
            builder.HasKey(section => section.Id);
            builder.HasIndex(section => section.Id).IsUnique();
            builder.Property(section => section.Name).HasMaxLength(100);
        }
    }
}
