using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SfPUT.Backend.Domain.Models;

namespace SfPUT.Backend.Persistence.EntityTypeConfigurations
{
    public class RateConfiguration:IEntityTypeConfiguration<Rate>
    {
        public void Configure(EntityTypeBuilder<Rate> builder)
        {
            builder.HasKey(rate => rate.Id);
            builder.HasIndex(rate => rate.Id).IsUnique();
            // TODO: fix
            // builder.Property(rate => rate.Post).IsRequired();
        }
    }
}
