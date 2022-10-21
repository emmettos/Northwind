using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EoSoftware.Northwind.Domain;

namespace EoSoftware.Northwind.Persistence;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("employees");

        builder.Property(e => e.EmployeeId)
            .ValueGeneratedNever()
            .HasColumnName("employee_id");

        builder.Property(e => e.Address)
            .HasMaxLength(60)
            .HasColumnName("address");

        builder.Property(e => e.BirthDate).HasColumnName("birth_date");

        builder.Property(e => e.City)
            .HasMaxLength(15)
            .HasColumnName("city");

        builder.Property(e => e.Country)
            .HasMaxLength(15)
            .HasColumnName("country");

        builder.Property(e => e.Extension)
            .HasMaxLength(4)
            .HasColumnName("extension");

        builder.Property(e => e.FirstName)
            .HasMaxLength(10)
            .HasColumnName("first_name");

        builder.Property(e => e.HireDate).HasColumnName("hire_date");

        builder.Property(e => e.HomePhone)
            .HasMaxLength(24)
            .HasColumnName("home_phone");

        builder.Property(e => e.LastName)
            .HasMaxLength(20)
            .HasColumnName("last_name");

        builder.Property(e => e.Notes).HasColumnName("notes");

        builder.Property(e => e.Photo).HasColumnName("photo");

        builder.Property(e => e.PhotoPath)
            .HasMaxLength(255)
            .HasColumnName("photo_path");

        builder.Property(e => e.PostalCode)
            .HasMaxLength(10)
            .HasColumnName("postal_code");

        builder.Property(e => e.Region)
            .HasMaxLength(15)
            .HasColumnName("region");

        builder.Property(e => e.ReportsTo).HasColumnName("reports_to");

        builder.Property(e => e.Title)
            .HasMaxLength(30)
            .HasColumnName("title");

        builder.Property(e => e.TitleOfCourtesy)
            .HasMaxLength(25)
            .HasColumnName("title_of_courtesy");

        builder.HasOne(d => d.ReportsToNavigation)
            .WithMany(p => p.InverseReportsToNavigation)
            .HasForeignKey(d => d.ReportsTo)
            .HasConstraintName("fk_employees_employees");

        builder.HasMany(d => d.Territories)
            .WithMany(p => p.Employees)
            .UsingEntity<Dictionary<string, object>>(
                "EmployeeTerritory",
                l => l.HasOne<Territory>().WithMany().HasForeignKey("TerritoryId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_employee_territories_territories"),
                r => r.HasOne<Employee>().WithMany().HasForeignKey("EmployeeId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_employee_territories_employees"),
                j =>
                {
                    j.HasKey("EmployeeId", "TerritoryId").HasName("pk_employee_territories");

                    j.ToTable("employee_territories");

                    j.IndexerProperty<short>("EmployeeId").HasColumnName("employee_id");

                    j.IndexerProperty<string>("TerritoryId").HasMaxLength(20).HasColumnName("territory_id");
                });
    }
}
