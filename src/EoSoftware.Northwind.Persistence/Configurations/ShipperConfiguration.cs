using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EoSoftware.Northwind.Domain.Entities;

namespace Northwind.Persistence.Configurations
{
    public class ShipperConfiguration : IEntityTypeConfiguration<Shipper>
    {
        public void Configure(EntityTypeBuilder<Shipper> builder)
        {
            builder.ToTable("shippers");

            builder.Property(e => e.ShipperId)
                .ValueGeneratedNever()
                .HasColumnName("shipper_id");

            builder.Property(e => e.CompanyName)
                .HasMaxLength(40)
                .HasColumnName("company_name");

            builder.Property(e => e.Phone)
                .HasMaxLength(24)
                .HasColumnName("phone");
        }
    }
}
