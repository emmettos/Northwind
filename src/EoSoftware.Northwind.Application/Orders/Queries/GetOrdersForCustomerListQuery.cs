using MediatR;
using Microsoft.EntityFrameworkCore;
using EoSoftware.Northwind.Domain;

namespace EoSoftware.Northwind.Application;

public class GetOrdersForCustomerListQuery : IRequest<IEnumerable<OrderDto>>
{
    public string? EmailAddress { get; set; }

    public class Handler : IRequestHandler<GetOrdersForCustomerListQuery, IEnumerable<OrderDto>>
    {
        private readonly INorthwindDbContext _context;

        public Handler(INorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderDto>> Handle(GetOrdersForCustomerListQuery request, CancellationToken cancellationToken)
        {
            return await _context.Set<Order>()
                .Where(o => o.Customer != null ? o.Customer.ContactName == request.EmailAddress : false)
                .Select(OrderDto.Projection)
                .ToListAsync(cancellationToken);
        }
    }
}
