using MediatR;
using Microsoft.EntityFrameworkCore;
using EoSoftware.Northwind.Domain;

namespace EoSoftware.Northwind.Application;

public class GetSuppliersListQuery : IRequest<IEnumerable<SupplierDto>>
{
    public class Handler : IRequestHandler<GetSuppliersListQuery, IEnumerable<SupplierDto>>
    {
        private readonly INorthwindDbContext _context;

        public Handler(INorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SupplierDto>> Handle(GetSuppliersListQuery request, CancellationToken cancellationToken)
        {
            return  await _context.Set<Supplier>()
                .AsNoTracking()
                .Select(s => s.ToSupplierDto())
                .ToListAsync(cancellationToken);
        }
    }
}
