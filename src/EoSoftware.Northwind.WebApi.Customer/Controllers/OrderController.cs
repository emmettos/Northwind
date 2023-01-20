using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EoSoftware.Northwind.Application;

namespace EoSoftware.Northwind.WebApi.Customer;

[Authorize]
[ApiController]
[Route("api/order")]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrdersAsync()
    {
        var orders = await _mediator.Send(new GetOrdersForCustomerListQuery{ EmailAddress = "Thomas Hardy" });

        if (orders == null)
        {
            return NoContent();
        }

        return Ok(orders);
    }
}
