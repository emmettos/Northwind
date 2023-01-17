using MediatR;
using EoSoftware.Northwind.Domain;

namespace EoSoftware.Northwind.Application;

public class UpdateSupplierCommand : IRequest<Unit>
{
    public SupplierDto? SupplierDto { get; set; }

    public class Handler : IRequestHandler<UpdateSupplierCommand, Unit>
    {
        private readonly INorthwindDbContext _context;

        public Handler(INorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            var updatedSupplier = request.SupplierDto!.ToSupplier();

            _context.Update<Supplier>(updatedSupplier);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
