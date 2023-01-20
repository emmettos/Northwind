using MediatR;
using Microsoft.EntityFrameworkCore;
using EoSoftware.Northwind.Domain;

namespace EoSoftware.Northwind.Application;

public class GetCategoryQuery : IRequest<CategoryDto?>
{
    public short Id { get; set; }

    public class Handler : IRequestHandler<GetCategoryQuery, CategoryDto?>
    {
        private readonly INorthwindDbContext _context;

        public Handler(INorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<CategoryDto?> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            return await _context.Set<Category>()
                .Where(c => c.CategoryId == request.Id)
                .Select(CategoryDto.Projection)
                .FirstOrDefaultAsync();
        }
    }
}
