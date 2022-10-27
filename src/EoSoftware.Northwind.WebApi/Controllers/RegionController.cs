using MediatR;
using Microsoft.AspNetCore.Mvc;
using EoSoftware.Northwind.Application;

namespace EoSoftware.Northwind.WebApi.Controllers;

[ApiController]
[Route("api/region")]
public class RegionController : ControllerBase
{
    private readonly IMediator _mediator;

    public RegionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RegionDto>>> GetRegions()
    {
        var regions = await _mediator.Send(new GetRegionsListQuery());

        return Ok(regions);
    }
}
