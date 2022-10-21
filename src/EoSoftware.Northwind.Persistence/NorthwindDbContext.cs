using Microsoft.EntityFrameworkCore;
using EoSoftware.Northwind.Application;

namespace EoSoftware.Northwind.Persistence;

public partial class NorthwindDbContext : DbContext, INorthwindDbContext
{
    public NorthwindDbContext()
    {
    }

    public NorthwindDbContext(DbContextOptions<NorthwindDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(NorthwindDbContext).Assembly);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
