using System.ComponentModel.DataAnnotations;

namespace EoSoftware.Northwind.Application;

public class NewCategoryDto
{
    [Required]
    [StringLength(15, MinimumLength = 3)]
    public string Name { get; set; } = null!;
    [Required]
    public string? Description { get; set; }
}

public class CategoryDto : NewCategoryDto
{
    public short Id { get; set; }
}
