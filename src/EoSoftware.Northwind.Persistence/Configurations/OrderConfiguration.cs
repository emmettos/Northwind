using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EoSoftware.Northwind.Domain.Entities;

namespace Northwind.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("orders");

            builder.Property(e => e.OrderId)
                .ValueGeneratedNever()
                .HasColumnName("order_id");

            builder.Property(e => e.CustomerId)
                .HasColumnType("char")
                .HasColumnName("customer_id");

            builder.Property(e => e.EmployeeId).HasColumnName("employee_id");

            builder.Property(e => e.Freight).HasColumnName("freight");

            builder.Property(e => e.OrderDate).HasColumnName("order_date");

            builder.Property(e => e.RequiredDate).HasColumnName("required_date");

            builder.Property(e => e.ShipAddress)
                .HasMaxLength(60)
                .HasColumnName("ship_address");

            builder.Property(e => e.ShipCity)
                .HasMaxLength(15)
                .HasColumnName("ship_city");

            builder.Property(e => e.ShipCountry)
                .HasMaxLength(15)
                .HasColumnName("ship_country");

            builder.Property(e => e.ShipName)
                .HasMaxLength(40)
                .HasColumnName("ship_name");

            builder.Property(e => e.ShipPostalCode)
                .HasMaxLength(10)
                .HasColumnName("ship_postal_code");

            builder.Property(e => e.ShipRegion)
                .HasMaxLength(15)
                .HasColumnName("ship_region");

            builder.Property(e => e.ShipVia).HasColumnName("ship_via");

            builder.Property(e => e.ShippedDate).HasColumnName("shipped_date");

            builder.HasOne(d => d.Customer)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("fk_orders_customers");

            builder.HasOne(d => d.Employee)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("fk_orders_employees");

            builder.HasOne(d => d.ShipViaNavigation)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.ShipVia)
                .HasConstraintName("fk_orders_shippers");
        }
    }
}
