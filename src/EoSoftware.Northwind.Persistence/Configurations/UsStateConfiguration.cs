using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EoSoftware.Northwind.Domain.Entities;

namespace Northwind.Persistence.Configurations
{
    public class UsStateConfiguration : IEntityTypeConfiguration<UsState>
    {
        public void Configure(EntityTypeBuilder<UsState> builder)
        {
            builder.HasKey(e => e.StateId)
                .HasName("pk_usstates");

            builder.ToTable("us_states");

            builder.Property(e => e.StateId)
                .ValueGeneratedNever()
                .HasColumnName("state_id");

            builder.Property(e => e.StateAbbr)
                .HasMaxLength(2)
                .HasColumnName("state_abbr");

            builder.Property(e => e.StateName)
                .HasMaxLength(100)
                .HasColumnName("state_name");

            builder.Property(e => e.StateRegion)
                .HasMaxLength(50)
                .HasColumnName("state_region");
        }
    }
}
