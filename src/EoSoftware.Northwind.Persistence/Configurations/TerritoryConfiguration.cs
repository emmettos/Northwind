using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EoSoftware.Northwind.Domain.Entities;

namespace Northwind.Persistence.Configurations
{
    public class TerritoryConfiguration : IEntityTypeConfiguration<Territory>
    {
        public void Configure(EntityTypeBuilder<Territory> builder)
        {
            builder.ToTable("territories");

            builder.Property(e => e.TerritoryId)
                .HasMaxLength(20)
                .HasColumnName("territory_id");

            builder.Property(e => e.RegionId).HasColumnName("region_id");

            builder.Property(e => e.TerritoryDescription)
                .HasColumnType("char")
                .HasColumnName("territory_description");

            builder.HasOne(d => d.Region)
                .WithMany(p => p.Territories)
                .HasForeignKey(d => d.RegionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_territories_region");
        }
    }
}
