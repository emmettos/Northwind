using System.ComponentModel.DataAnnotations;

namespace EoSoftware.Northwind.Application;

public class NewRegionDto
{   
    public string Description { get; set; } = null!;
}

public class RegionDto : NewRegionDto
{
    [Required]
    [Range(1, 999999999)]
    public short? Id { get; set; }
}
