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
            var categoryDto = await _context.Set<Category>()
                .AsNoTracking()
                .Where(c => c.CategoryId == request.Id)
                .Select(c => c.ToCategoryDto())
                .FirstOrDefaultAsync();

            return categoryDto; 
        }
    }
}
