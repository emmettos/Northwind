using MediatR;
using Microsoft.EntityFrameworkCore;
using EoSoftware.Northwind.Domain;

namespace EoSoftware.Northwind.Application;

public class GetRegionsListQuery : IRequest<IList<RegionDto>>
{
    public class Handler : IRequestHandler<GetRegionsListQuery, IList<RegionDto>>
    {
        private readonly INorthwindDbContext _context;

        public Handler(INorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<IList<RegionDto>> Handle(GetRegionsListQuery request, CancellationToken cancellationToken)
        {
            return  await _context.Set<Region>().Select(r => r.ToRegionDto()).ToListAsync(cancellationToken);
        }
    }
}
