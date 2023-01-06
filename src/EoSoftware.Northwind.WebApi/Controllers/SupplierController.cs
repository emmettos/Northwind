using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EoSoftware.Northwind.Application;

namespace EoSoftware.Northwind.WebApi;

[Authorize(Roles = "Application.Admin, Supplier.Admin, Supplier.Specialist")]
[ApiController]
[Route("api/supplier")]
public class SupplierController : ControllerBase
{
    private readonly IMediator _mediator;

    public SupplierController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SupplierDto>>> GetSuppliersAsync()
    {
        var suppliers = await _mediator.Send(new GetSuppliersListQuery());

        if (suppliers == null)
        {
            return NoContent();
        }

        return Ok(suppliers);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetSupplierAsync(short Id)
    {
        var supplierDto = await _mediator.Send(new GetSupplierQuery { Id = Id });

        if (supplierDto == null)
        {
            return NotFound();
        }

        return Ok(supplierDto);
    }

    [Authorize(Roles = "Application.Admin, Supplier.Admin")]
    [HttpPost]
    public async Task<ActionResult<SupplierDto>> CreateSupplierAsync(NewSupplierDto newSupplierDto)
    {
        var createdSupplierDto = await _mediator.Send(new CreateSupplierCommand { NewSupplierDto = newSupplierDto });

        return CreatedAtAction("GetSupplier", new { Id = createdSupplierDto.Id }, createdSupplierDto);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateSupplierAsync(SupplierDto updatedSupplierDto)
    {
        await _mediator.Send(new UpdateSupplierCommand { SupplierDto = updatedSupplierDto });

        return new NoContentResult();
    }
}
