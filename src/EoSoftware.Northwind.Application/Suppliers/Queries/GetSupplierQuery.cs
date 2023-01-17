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
            var supplierDto = await _context.Set<Supplier>()
                .AsNoTracking()
                .Where(c => c.SupplierId == request.Id)
                .Select(c => c.ToSupplierDto())
                .FirstOrDefaultAsync();

            return supplierDto; 
        }
    }
}
