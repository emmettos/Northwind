using MediatR;
using EoSoftware.Northwind.Domain;

namespace EoSoftware.Northwind.Application;

public class CreateCategoryCommand : IRequest<CategoryDto>
{
    public NewCategoryDto? NewCategoryDto { get; set; }

    public class Handler : IRequestHandler<CreateCategoryCommand, CategoryDto>
    {
        private readonly INorthwindDbContext _context;

        public Handler(INorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var newCategory = request.NewCategoryDto!.ToCategory();

            _context.Set<Category>().Add(newCategory);

            await _context.SaveChangesAsync(cancellationToken);

            return newCategory.ToCategoryDto();
        }
    }
}
