using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using EoSoftware.Northwind.Domain;

namespace EoSoftware.Northwind.Application;

public class NewCategoryDto
{
    [Required]
    [StringLength(15, MinimumLength = 3)]
    public string Name { get; set; } = null!;
    [Required]
    public string? Description { get; set; }

    public static Expression<Func<Category, CategoryDto>> Projection
    {
        get
        {
            return c => new CategoryDto()
            {
                Id = c.CategoryId, 
                Name = c.CategoryName,
                Description = c.Description,
            };
        }
    }
}

public class CategoryDto : NewCategoryDto
{
    [Required]
    [Range(1, 999999999)]
    public short? Id { get; set; }
}
