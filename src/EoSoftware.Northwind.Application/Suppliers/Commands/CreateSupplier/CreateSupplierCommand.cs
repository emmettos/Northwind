using MediatR;
using EoSoftware.Northwind.Domain;

namespace EoSoftware.Northwind.Application;

public class CreateSupplierCommand : IRequest<SupplierDto>
{
    public NewSupplierDto? NewSupplierDto { get; set; }

    public class Handler : IRequestHandler<CreateSupplierCommand, SupplierDto>
    {
        private readonly INorthwindDbContext _context;

        public Handler(INorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<SupplierDto> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            var newSupplier = request.NewSupplierDto!.ToSupplier();

            _context.Set<Supplier>().Add(newSupplier);

            await _context.SaveChangesAsync(cancellationToken);

            return newSupplier.ToSupplierDto();
        }
    }
}
