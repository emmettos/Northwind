using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EoSoftware.Northwind.Application;

namespace EoSoftware.Northwind.WebApi;

[Authorize(Roles = "Application.Admin")]
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
    public async Task<ActionResult<IEnumerable<RegionDto>>> GetRegionsAsync()
    {
        var regions = await _mediator.Send(new GetRegionsListQuery());

        return Ok(regions);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetRegionAsync(short Id)
    {
        var regionDto = await _mediator.Send(new GetRegionQuery { Id = Id });

        if (regionDto == null)
        {
            return NotFound();
        }

        return Ok(regionDto);
    }

    [HttpPost]
    public async Task<ActionResult<RegionDto>> CreateRegionAsync(NewRegionDto newRegionDto)
    {
        var createdRegionDto = await _mediator.Send(new CreateRegionCommand { NewRegionDto = newRegionDto });

        return CreatedAtAction("GetRegion", new { Id = createdRegionDto.Id }, createdRegionDto);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateRegionAsync(RegionDto updatedRegionDto)
    {
        await _mediator.Send(new UpdateRegionCommand { RegionDto = updatedRegionDto });

        return new NoContentResult();
    }
}
