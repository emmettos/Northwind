using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EoSoftware.Northwind.Application
{
    public interface INorthwindDbContext
    {
        DbSet<T> Set<T>() where T : class;

        EntityEntry<T> Update<T> (T entity) where T : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
