using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EoSoftware.Northwind.Domain.Entities;

namespace Northwind.Persistence.Configurations
{
    public class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.ToTable("region");

            builder.Property(e => e.RegionId)
                .ValueGeneratedNever()
                .HasColumnName("region_id");

            builder.Property(e => e.RegionDescription)
                .HasColumnType("char")
                .HasColumnName("region_description");
        }
    }
}
