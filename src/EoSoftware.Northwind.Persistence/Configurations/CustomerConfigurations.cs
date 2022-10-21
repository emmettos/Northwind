using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EoSoftware.Northwind.Domain;

namespace EoSoftware.Northwind.Persistence;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("customers");

        builder.Property(e => e.CustomerId)
            .HasColumnType("char")
            .ValueGeneratedNever()
            .HasColumnName("customer_id");

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

        builder.Property(e => e.Phone)
            .HasMaxLength(24)
            .HasColumnName("phone");

        builder.Property(e => e.PostalCode)
            .HasMaxLength(10)
            .HasColumnName("postal_code");

        builder.Property(e => e.Region)
            .HasMaxLength(15)
            .HasColumnName("region");

        builder.HasMany(d => d.CustomerTypes)
            .WithMany(p => p.Customers)
            .UsingEntity<Dictionary<string, object>>(
                "CustomerCustomerDemo",
                l => l.HasOne<CustomerDemographic>().WithMany().HasForeignKey("CustomerTypeId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_customer_customer_demo_customer_demographics"),
                r => r.HasOne<Customer>().WithMany().HasForeignKey("CustomerId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_customer_customer_demo_customers"),
                j =>
                {
                    j.HasKey("CustomerId", "CustomerTypeId").HasName("pk_customer_customer_demo");

                    j.ToTable("customer_customer_demo");

                    j.IndexerProperty<char>("CustomerId").HasColumnType("char").HasColumnName("customer_id");

                    j.IndexerProperty<char>("CustomerTypeId").HasColumnType("char").HasColumnName("customer_type_id");
                });
    }
}
