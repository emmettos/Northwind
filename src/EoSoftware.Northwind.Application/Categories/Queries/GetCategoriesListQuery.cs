using MediatR;
using Microsoft.EntityFrameworkCore;
using EoSoftware.Northwind.Domain;

namespace EoSoftware.Northwind.Application;

public class GetCategoriesListQuery : IRequest<IEnumerable<CategoryDto>>
{
    public class Handler : IRequestHandler<GetCategoriesListQuery, IEnumerable<CategoryDto>>
    {
        private readonly INorthwindDbContext _context;

        public Handler(INorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoryDto>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            return await _context.Set<Category>()
                .Select(CategoryDto.Projection)
                .ToListAsync(cancellationToken);
        }
    }
}
