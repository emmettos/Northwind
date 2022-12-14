using MediatR;
using EoSoftware.Northwind.Domain;

namespace EoSoftware.Northwind.Application;

public class CreateRegionCommand : IRequest<RegionDto>
{
    public NewRegionDto? NewRegionDto { get; set; }

    public class Handler : IRequestHandler<CreateRegionCommand, RegionDto>
    {
        private readonly INorthwindDbContext _context;

        public Handler(INorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<RegionDto> Handle(CreateRegionCommand request, CancellationToken cancellationToken)
        {
            var newRegion = request.NewRegionDto!.ToRegion();

            _context.Set<Region>().Add(newRegion);

            await _context.SaveChangesAsync(cancellationToken);

            return newRegion.ToRegionDto();
        }
    }
}
