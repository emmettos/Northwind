using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using EoSoftware.Northwind.Domain;

namespace EoSoftware.Northwind.Application;

public class NewRegionDto
{   
    public string Description { get; set; } = null!;

    public static Expression<Func<Region, RegionDto>> Projection
    {
        get
        {
            return r => new RegionDto()
            {
                Id = r.RegionId, 
                Description = r.RegionDescription
            };
        }
    }
}

public class RegionDto : NewRegionDto
{
    [Required]
    [Range(1, 999999999)]
    public short? Id { get; set; }
}
