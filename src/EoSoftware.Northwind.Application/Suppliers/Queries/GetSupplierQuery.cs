using MediatR;
using Microsoft.EntityFrameworkCore;
using EoSoftware.Northwind.Domain;

namespace EoSoftware.Northwind.Application;

public class GetSupplierQuery : IRequest<SupplierDto?>
{
    public short Id { get; set; }

    public class Handler : IRequestHandler<GetSupplierQuery, SupplierDto?>
    {
        private readonly INorthwindDbContext _context;

        public Handler(INorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<SupplierDto?> Handle(GetSupplierQuery request, CancellationToken cancellationToken)
        {
            return await _context.Set<Supplier>()
                .Where(s => s.SupplierId == request.Id)
                .Select(SupplierDto.Projection)
                .FirstOrDefaultAsync();
        }
    }
}
