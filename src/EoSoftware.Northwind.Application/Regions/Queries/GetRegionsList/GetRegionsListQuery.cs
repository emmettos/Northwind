using MediatR;
using Microsoft.EntityFrameworkCore;
using EoSoftware.Northwind.Domain;

namespace EoSoftware.Northwind.Application;

public class GetRegionsListQuery : IRequest<IEnumerable<RegionDto>>
{
    public class Handler : IRequestHandler<GetRegionsListQuery, IEnumerable<RegionDto>>
    {
        private readonly INorthwindDbContext _context;

        public Handler(INorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RegionDto>> Handle(GetRegionsListQuery request, CancellationToken cancellationToken)
        {
            return  await _context.Set<Region>()
                .AsNoTracking()
                .Select(r => r.ToRegionDto())
                .ToListAsync(cancellationToken);
        }
    }
}
