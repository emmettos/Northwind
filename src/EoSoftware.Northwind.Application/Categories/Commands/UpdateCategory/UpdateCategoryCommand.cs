using MediatR;
using EoSoftware.Northwind.Domain;

namespace EoSoftware.Northwind.Application;

public class UpdateCategoryCommand : IRequest<Unit>
{
    public CategoryDto? CategoryDto { get; set; }

    public class Handler : IRequestHandler<UpdateCategoryCommand, Unit>
    {
        private readonly INorthwindDbContext _context;

        public Handler(INorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var updatedCategory = request.CategoryDto!.ToCategory();

            _context.Update<Category>(updatedCategory);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
