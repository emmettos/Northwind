using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EoSoftware.Northwind.Domain;

namespace EoSoftware.Northwind.Persistence;

public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.ToTable("suppliers");

        builder.Property(e => e.SupplierId)
            .HasColumnName("supplier_id")
            .UseIdentityAlwaysColumn();

        builder.Property(e => e.Address)
            .HasMaxLength(60)
            .HasColumnName("address");

        builder.Property(e => e.City)
            .HasMaxLength(15)
            .HasColumnName("city");

        builder.Property(e => e.CompanyName)
            .HasMaxLength(40)
            .HasColumnName("company_name");

        builder.Property(e => e.ContactName)
            .HasMaxLength(30)
            .HasColumnName("contact_name");

        builder.Property(e => e.ContactTitle)
            .HasMaxLength(30)
            .HasColumnName("contact_title");

        builder.Property(e => e.Country)
            .HasMaxLength(15)
            .HasColumnName("country");

        builder.Property(e => e.Fax)
            .HasMaxLength(24)
            .HasColumnName("fax");

        builder.Property(e => e.Homepage).HasColumnName("homepage");

        builder.Property(e => e.Phone)
            .HasMaxLength(24)
            .HasColumnName("phone");

        builder.Property(e => e.PostalCode)
            .HasMaxLength(10)
            .HasColumnName("postal_code");

        builder.Property(e => e.Region)
            .HasMaxLength(15)
            .HasColumnName("region");
    }
}
