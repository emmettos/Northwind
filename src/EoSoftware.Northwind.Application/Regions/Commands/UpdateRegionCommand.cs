using MediatR;
using EoSoftware.Northwind.Domain;

namespace EoSoftware.Northwind.Application;

public class UpdateRegionCommand : IRequest<Unit>
{
    public RegionDto? RegionDto { get; set; }

    public class Handler : IRequestHandler<UpdateRegionCommand, Unit>
    {
        private readonly INorthwindDbContext _context;

        public Handler(INorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateRegionCommand request, CancellationToken cancellationToken)
        {
            var updatedRegion = request.RegionDto!.ToRegion();

            _context.Update<Region>(updatedRegion);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
