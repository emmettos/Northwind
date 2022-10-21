using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EoSoftware.Northwind.Domain;

namespace EoSoftware.Northwind.Persistence;

public class CustomerDemographicConfiguration : IEntityTypeConfiguration<CustomerDemographic>
{
    public void Configure(EntityTypeBuilder<CustomerDemographic> builder)
    {
        builder.HasKey(e => e.CustomerTypeId)
            .HasName("pk_customer_demographics");

        builder.ToTable("customer_demographics");

        builder.Property(e => e.CustomerTypeId)
            .HasColumnType("char")
            .ValueGeneratedNever()
            .HasColumnName("customer_type_id");

        builder.Property(e => e.CustomerDesc).HasColumnName("customer_desc");
    }
}
