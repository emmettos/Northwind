using MediatR;
using Microsoft.AspNetCore.Mvc;
using EoSoftware.Northwind.Application;

namespace EoSoftware.Northwind.WebApi.Controllers;

[ApiController]
[Route("api/category")]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategoriesAsync()
    {
        var categories = await _mediator.Send(new GetCategoriesListQuery());

        if (categories == null)
        {
            return NoContent();
        }

        return Ok(categories);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetCategoryAsync(short Id)
    {
        var categoryDto = await _mediator.Send(new GetCategoryQuery { Id = Id });

        if (categoryDto == null)
        {
            return NotFound();
        }

        return Ok(categoryDto);
    }

    [HttpPost]
    public async Task<ActionResult<CategoryDto>> CreateCategoryAsync(NewCategoryDto newCategoryDto)
    {
        var createdCategoryDto = await _mediator.Send(new CreateCategoryCommand { NewCategoryDto = newCategoryDto });

        return CreatedAtAction("GetCategory", new { Id = createdCategoryDto.Id }, createdCategoryDto);
    }
}
