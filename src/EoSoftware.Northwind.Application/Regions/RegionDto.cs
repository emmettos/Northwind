using System.ComponentModel.DataAnnotations;

namespace EoSoftware.Northwind.Application;

public class RegionDto
{   [Required]
    [Range(1, 999999999)]
    public short? Id { get; set; }

    public string Description { get; set; } = null!;
}
