using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using EoSoftware.Northwind.Application.Interfaces;
using EoSoftware.Northwind.Domain.Entities;

namespace EoSoftware.Northwind.WebApi.Controllers;

[ApiController]
[Route("api/region")]
public class RegionController : ControllerBase
{
    private INorthwindDbContext _context;

    public RegionController(INorthwindDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Region>>> GetRegions()
    {
        return await _context.Set<Region>().ToListAsync();
    }
}
