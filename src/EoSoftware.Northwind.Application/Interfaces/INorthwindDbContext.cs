using Microsoft.EntityFrameworkCore;

namespace EoSoftware.Northwind.Application.Interfaces
{
    public interface INorthwindDbContext
    {
        DbSet<T> Set<T>() where T : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}