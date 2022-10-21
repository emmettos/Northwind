using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EoSoftware.Northwind.Domain;

namespace EoSoftware.Northwind.Persistence;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("categories");

        builder.Property(e => e.CategoryId)
            .ValueGeneratedNever()
            .HasColumnName("category_id");

        builder.Property(e => e.CategoryName)
            .HasMaxLength(15)
            .HasColumnName("category_name");

        builder.Property(e => e.Description).HasColumnName("description");

        builder.Property(e => e.Picture).HasColumnName("picture");
    }
}
