using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EoSoftware.Northwind.Interfaces
{
    public interface INorthwindDbContext
    {
        DbSet<T> Set<T>() where T : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
